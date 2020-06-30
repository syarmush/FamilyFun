using System;
using Microsoft.AspNetCore.Mvc;
using FamilyFun.Models;
using FamilyFun.Persistance;
using System.Collections;
using FamilyFun.Web.Models;
using System.Collections.Generic;

namespace FamilyFun.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _persistanceWorker;

        public HomeController(UnitOfWork persistanceWorker)
        {
            _persistanceWorker = persistanceWorker ?? throw new ArgumentNullException(nameof(persistanceWorker));
        }

        public IActionResult Index()
        {
            IList<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("Item 1", "Item1", "/images/image1.jpg"),
                new MenuItem("Item 2", "Item2", "/images/image2.jpg"),
                new MenuItem("Item 3", "Item3", "/images/image3.jpg"),
                new MenuItem("Item 4", "Item4", "/images/image4.jpg"),
                new MenuItem("Item 5", "Item5", "/images/image5.jpg"),
                new MenuItem("Item 6", "Item6", "/images/image6.jpg"),
                new MenuItem("Item 7", "Item7", "/images/image7.jpg"),
                new MenuItem("Item 8", "Item8", "/images/image8.jpg"),
                new MenuItem("Item 9", "Item9", "/images/image9.jpg")
            };

            ViewBag.MenuItems = menuItems;
            return View();
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
