using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FamilyFun.Web.Models;

namespace FamilyFun.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFamilyMembersSelectorElementRetriever _familyMemberSelectorRetriever;
        private readonly IMenuItemSelectorElementRetriever _menuItemSelectorRetriver;
        private readonly IPageColorDeterminer _colorDeterminer;

        public HomeController(IFamilyMembersSelectorElementRetriever familyMemberSelectorRetriever, IPageColorDeterminer colorDeterminer,
            IMenuItemSelectorElementRetriever menuItemSelectorRetriver)
        {
            _familyMemberSelectorRetriever = familyMemberSelectorRetriever ?? throw new ArgumentNullException(nameof(familyMemberSelectorRetriever));
            _colorDeterminer = colorDeterminer ?? throw new ArgumentNullException(nameof(colorDeterminer));
            _menuItemSelectorRetriver = menuItemSelectorRetriver ?? throw new ArgumentNullException(nameof(menuItemSelectorRetriver));
        }

        public IActionResult Index()
        {
            ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
            ViewBag.Title = "Home";

            return View("~/Views/Shared/MenuSelector.cshtml", _familyMemberSelectorRetriever.RetriveSelectorElements());
        }

        [HttpGet("/Home/{id}")]
        public IActionResult Index(int id)
        {
            ViewBag.UrlRouteId = id;
            ViewBag.PageColors = _colorDeterminer.DeterminePageBackgroundColors();
            ViewBag.Title = "Menu";

            return View("~/Views/Shared/MenuSelector.cshtml", _menuItemSelectorRetriver.RetrieveByFamilyMemberId(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
