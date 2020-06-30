//using System;
//using Microsoft.AspNetCore.Mvc;
//using FamilyFun.Domain;
//using FamilyFun.Persistance;

//namespace FamilyFun.Web.Controllers
//{
//    public class MedicinesController : Controller
//    {
//        private readonly UnitOfWork _persistanceWorker;

//        public MedicinesController(UnitOfWork persistanceWorker)
//        {
//            _persistanceWorker = persistanceWorker ?? throw new ArgumentNullException(nameof(persistanceWorker));
//        }

//        // GET: Medicines
//        public IActionResult Index()
//        {
//            return View(_persistanceWorker.Medicines.GetAll());
//        }

//        // GET: Medicines/Details/5
//        public IActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var medicine = _persistanceWorker.Medicines.GetOne(id);

//            if (medicine == null)
//            {
//                return NotFound();
//            }

//            return View(medicine);
//        }

//        // GET: Medicines/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Medicines/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create([Bind("Name")] Medicine medicine)
//        {
//            if (ModelState.IsValid)
//            {
//                _persistanceWorker.Medicines.Insert(medicine);
//                _persistanceWorker.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(medicine);
//        }

//        // GET: Medicines/Edit/5
//        public IActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var medicine = _persistanceWorker.Medicines.GetOne(id);

//            if (medicine == null)
//            {
//                return NotFound();
//            }
//            return View(medicine);
//        }

//        // POST: Medicines/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(string id, [Bind("Name,Id")] Medicine medicine)
//        {
//            if (id != medicine.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                _persistanceWorker.Medicines.Update(medicine);
//                _persistanceWorker.SaveChanges();

//                return RedirectToAction(nameof(Index));
//            }
//            return View(medicine);
//        }

//        // GET: Medicines/Delete/5
//        public IActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Medicine medicine = _persistanceWorker.Medicines.GetOne(id);

//            if (medicine == null)
//            {
//                return NotFound();
//            }

//            return View(medicine);
//        }

//        // POST: Medicines/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(string id)
//        {
//            Medicine medicine = _persistanceWorker.Medicines.GetOne(id);
//            medicine.IsDeleted = true;
//            _persistanceWorker.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
