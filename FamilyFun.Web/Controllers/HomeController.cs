using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FamilyFun.Web.Models;

namespace FamilyFun.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFamilyMembersSelectorElementRetriever _familyMemberSelectorRetriever;
        private readonly IMenuItemSelectorElementRetriever _activityMenuSelectorRetriever;
        private readonly IPageColorDeterminer _colorDeterminer;

        public HomeController(IFamilyMembersSelectorElementRetriever familyMemberSelectorRetriever, IPageColorDeterminer colorDeterminer,
            IMenuItemSelectorElementRetriever activityMenuSelectorRetriever)
        {
            _familyMemberSelectorRetriever = familyMemberSelectorRetriever ?? throw new ArgumentNullException(nameof(familyMemberSelectorRetriever));
            _colorDeterminer = colorDeterminer ?? throw new ArgumentNullException(nameof(colorDeterminer));
            _activityMenuSelectorRetriever = activityMenuSelectorRetriever ?? throw new ArgumentNullException(nameof(activityMenuSelectorRetriever));
        }

        public IActionResult Index()
        {
            ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
            ViewBag.Title = "Home";

            return View("FamilyMenuSelector", _familyMemberSelectorRetriever.RetriveSelectorElements());
        }

        [HttpGet("/Home/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.UrlRouteId = id;
            ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
            ViewBag.Title = "Menu";

            return View("ActivityMenuSelector", _activityMenuSelectorRetriever.RetrieveByFamilyMemberId(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
