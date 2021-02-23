using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using FamilyFun.Web.Models.ViewModels;
using FamilyFun.Web.Persistance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult Index(int id)
        {
            ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
            IEnumerable<SelectorElement> mitzvosSelectors = _mitzvosSelectorRetriever.RetrieveByFamilyMemberId(id).ToList();

            return View("MitzvahMenuSelector", new MitzvahMenuModelView(id, mitzvosSelectors));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddMitzvah(MitzvahOccuranceViewModel mitzvahOccurance)
        {
            mitzvahOccurance.MitzvahDate = mitzvahOccurance.MitzvahDate ?? DateTime.Today;

            if (await _mitzvahRepository.MemberHasMitzvahForDate(mitzvahOccurance.FamilyMemberId, mitzvahOccurance.MitzvahId, mitzvahOccurance.MitzvahDate.Value))
            {
                ModelState.AddModelError("mitzvahId", "Mitzvah already exists");
            }

            if (ModelState.IsValid)
            {
                FamilyMember member = _familyMembersRetriever.RetrieveFamilyMembers(m => m.Id == mitzvahOccurance.FamilyMemberId).Single();
                Mitzvah mitzvah = _mitzvosRetriever.RetrieveMitzvos(m => m.Id == mitzvahOccurance.MitzvahId).Single();

                ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
                await _mitzvahRepository.LogMitzvahPointsForDateAsync(mitzvahOccurance.FamilyMemberId, mitzvahOccurance.MitzvahId, mitzvahOccurance.MitzvahDate.Value, mitzvah.Points);

                return View(new AddMitzvahResult(member.Id, member.Name, mitzvah.Points));
            }

            return Index(mitzvahOccurance.FamilyMemberId);
        }

        [HttpGet("Admin/{fmId}/{date}")]
        public async Task<IActionResult> ViewLoggedMitzvos([FromRoute] int fmId, [FromRoute] DateTime date)
        {
            IDictionary<int, Mitzvah> mitzvos = _mitzvosRetriever.RetrieveMitzvos().ToDictionary(k => k.Id, v => v);
            IDictionary<int, FamilyMember> familyMembers = _familyMembersRetriever.RetrieveFamilyMembers().ToDictionary(k => k.Id, v => v);

            IEnumerable<MitzvahOccurence>? mitvosOccurances = await _mitzvahRepository.RetrieveAllMitzvahOccurencesAsync(fmId, date);
            IEnumerable<LoggedMitzvahViewModel> mitzvahOccurancesViewModels = mitvosOccurances
                .Select(mo => new LoggedMitzvahViewModel(mo.Id, familyMembers[mo.FamilyMemberId], mitzvos[mo.MitzvahId], mo.Points, mo.OccuredOn, mo.ApproveOn, mo.ApprovedBy));

            return View("LoggedMitzvos", mitzvahOccurancesViewModels);
        }

        [HttpGet("Approve/{id}")]
        public async Task<JsonResult> ApproveMitzvah(string id)
        {
            MitzvahOccurence mitzvahOccurence = await _mitzvahRepository.RetrieveSinlgeMitzvahOccuranceAsync(id);
            mitzvahOccurence.ApproveOn = DateTime.Now;
            mitzvahOccurence.ApprovedBy = "Anonymous";
            await _mitzvahRepository.UpdateAsync(mitzvahOccurence);

            return Json(new { success = true });
        }

        [HttpGet("Block/{id}")]
        public async Task<JsonResult> BlockMitzvah(string id)
        {
            MitzvahOccurence mitzvahOccurence = await _mitzvahRepository.RetrieveSinlgeMitzvahOccuranceAsync(id);
            mitzvahOccurence.ApproveOn = DateTime.Now;
            mitzvahOccurence.ApprovedBy = "Anonymous";
            mitzvahOccurence.Points = 0;
            await _mitzvahRepository.UpdateAsync(mitzvahOccurence);

            return Json(new { success = true });
        }

        [HttpGet("Delete/{id}")]
        public async Task<JsonResult> DeleteMitzvah(string id)
        {
            await _mitzvahRepository.DeleteSinlgeMitzvahOccuranceAsync(id);

            return Json(new { success = true });
        }
    }
}