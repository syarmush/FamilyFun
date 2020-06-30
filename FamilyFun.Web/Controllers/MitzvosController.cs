using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using FamilyFun.Web.Persistance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyFun.Web.Controllers
{
    [Route("[controller]")]
    public class MitzvosController : Controller
    {
        private readonly IMitzvahRepository _mitzvahRepository;
        private readonly IPageColorDeterminer _colorDeterminer;
        private readonly IMitzvosSelectorElementRetriever _mitzvosSelectorRetriever;
        private readonly IFamilyMembersRetriever _familyMembersRetriever;
        private readonly IMitzvosRetriever _mitzvosRetriever;

        public MitzvosController(IPageColorDeterminer colorDeterminer, IMitzvosSelectorElementRetriever mitzvosSelectorRetriever, 
            IMitzvahRepository mitzvahLogger, IFamilyMembersRetriever familyMembersRetriever, IMitzvosRetriever mitzvosRetriever)
        {
            _colorDeterminer = colorDeterminer ?? throw new ArgumentNullException(nameof(colorDeterminer));
            _mitzvosSelectorRetriever = mitzvosSelectorRetriever ?? throw new ArgumentNullException(nameof(mitzvosSelectorRetriever));
            _mitzvahRepository = mitzvahLogger ?? throw new ArgumentNullException(nameof(mitzvahLogger));
            _familyMembersRetriever = familyMembersRetriever ?? throw new ArgumentNullException(nameof(familyMembersRetriever));
            _mitzvosRetriever = mitzvosRetriever ?? throw new ArgumentNullException(nameof(mitzvosRetriever));
        }

        [HttpGet("{id}")]
        public IActionResult Index([FromRoute]int id)
        {
            ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();

            return View("~/Views/Shared/MenuSelector.cshtml", _mitzvosSelectorRetriever.RetrieveByFamilyMemberId(id));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddMitzvah([FromForm]int familyMemberId, [FromForm]int mitzvahId)
        {
            FamilyMember member = _familyMembersRetriever.RetrieveFamilyMembers(m => m.Id == familyMemberId).Single();
            Mitzvah mitzvah = _mitzvosRetriever.RetrieveMitzvos(m => m.Id == mitzvahId).Single();


            if (ModelState.IsValid)
            {
                ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
                await _mitzvahRepository.LogMitzvahAsync(mitzvahId, familyMemberId, mitzvah.Points);
                return View(new AddMitzvahResult(member.Name, mitzvah.Points));
            }

            return RedirectToAction(nameof(Index), new { familyMemberId });
        }

        [HttpGet("Prizes/{id}")]
        public async Task<IActionResult> Prizes([FromRoute] int id, [FromServices]IMemberPrizeRetriever prizeRetriever)
        {
            ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
            int points = (await _mitzvahRepository.RetriveMitzvosAsync(id)).Sum(m => m.Points);
            FamilyMember member = _familyMembersRetriever.RetrieveFamilyMembers(m => m.Id == id).Single();

            return View(new PrizeResult(member, points, prizeRetriever.RetrieveByFamilyMemberId(id)));
        }

        [HttpGet("Archive/{id}")]
        public async Task<IActionResult> ViewLoggedMitzvos([FromRoute] int id)
        {
            return new ObjectResult(await _mitzvahRepository.RetriveMitzvosAsync(id));
        }
    }
}