using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using FamilyFun.Web.Persistance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyFun.Web.Controllers
{
    public class PrizeController : Controller
    {
        private readonly IMitzvahRepository _mitzvahRepository;
        private readonly IPageColorDeterminer _colorDeterminer;
        private readonly IFamilyMembersRetriever _familyMembersRetriever;
        private readonly IPrizeImageDirectoryPathRetriever _imageDirectoryPathRetriever;

        public PrizeController(IPageColorDeterminer colorDeterminer, IMitzvahRepository mitzvahLogger, IFamilyMembersRetriever familyMembersRetriever,
            IPrizeImageDirectoryPathRetriever imageDirectoryPathRetriever)
        {
            _colorDeterminer = colorDeterminer ?? throw new ArgumentNullException(nameof(colorDeterminer));
            _mitzvahRepository = mitzvahLogger ?? throw new ArgumentNullException(nameof(mitzvahLogger));
            _familyMembersRetriever = familyMembersRetriever ?? throw new ArgumentNullException(nameof(familyMembersRetriever));
            _imageDirectoryPathRetriever = imageDirectoryPathRetriever ?? throw new ArgumentNullException(nameof(imageDirectoryPathRetriever));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id, [FromServices] IMemberPrizeRetriever prizeRetriever)
        {
            ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
            int approvedPoints = (await _mitzvahRepository.RetrieveApprovedMitzvahOccurencesAsync(id)).Sum(m => m.Points);
            int pendingPoints = (await _mitzvahRepository.RetrievePendingMitzvahOccurencesAsync(id)).Sum(m => m.Points);
            FamilyMember member = _familyMembersRetriever.RetrieveFamilyMembers(m => m.Id == id).Single();
            var prizeResult = new PrizeResultViewModel(member, approvedPoints, pendingPoints, prizeRetriever.RetrieveByFamilyMemberId(id), _imageDirectoryPathRetriever.RetrieveImageDirectoryPath());

            return View(prizeResult);
        }
    }
}
