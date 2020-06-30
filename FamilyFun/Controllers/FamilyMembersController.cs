//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using FamilyFun.Persistance;

//namespace FamilyFun.Web.Controllers
//{
//    public class FamilyMembersController : BaseController<string>
//    {
//        public FamilyMembersController(UnitOfWork persistanceWorker) : base(persistanceWorker)
//        {
//           // _persistanceWorker = persistanceWorker ?? throw new ArgumentNullException(nameof(persistanceWorker));
//        }
//        /*
//        // GET: FamilyMembers
//        [HttpGet("FamilyMembers/{familyId}")]
//        public IActionResult Index(string familyId)
//        {
//            ViewBag.FamilyId = familyId;

//            //ISet<string> familyMemberIds = _persistanceWorker.Repository<Family>().GetOne(familyId).FamilyMemberIds;

//            //return View(_persistanceWorker.Repository<FamilyMember>().GetAllWhere(fm => familyMemberIds.Contains( fm.Id)));
//        }

//        // GET: FamilyMembers/Create
//        [HttpGet("/FamilyMembers/Create")]
//        public IActionResult Create([FromQuery] string familyId)
//        {
//            ViewBag.FamilyId = familyId;
//            return View();
//        }
        
//        // POST: FamilyMembers/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost("/Family/{familyId}/FamilyMembers/Create")]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(string familyId, [Bind("Name")] FamilyMember familyMember)
//        {
//            if (ModelState.IsValid)
//            {
//                Family family = _persistanceWorker.Repository<Family>().GetOne(familyId);
//                _persistanceWorker.Repository<FamilyMember>().Insert(familyMember);
//                family.FamilyMemberIds.Add(familyMember.Id);
//                _persistanceWorker.Repository<Family>().Update(family);
//                _persistanceWorker.SaveChanges();
//                return RedirectToAction(nameof(Index), new { familyId = family.Id });
//            }
//            return View(familyMember);
//        }
        
//        // GET: Activities/Edit/5
//        public IActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var activity = _persistanceWorker.Activities.GetOne(id);
//            if (activity == null)
//            {
//                return NotFound();
//            }
//            return View(activity);
//        }

//        // POST: Activities/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(string id, [Bind("Name,Points")] Activity activity)
//        {
//            if (id != activity.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                Activity existingActivity = _persistanceWorker.Activities.GetOne(id);

//                if (existingActivity is null)
//                {
//                    return NotFound();
//                }

//                existingActivity.Name = activity.Name ?? existingActivity.Name;
//                existingActivity.Points = activity.Points;
//                _persistanceWorker.SaveChanges();

//                return RedirectToAction(nameof(Index));
//            }
//            return View(activity);
//        }

//        // GET: Activities/Delete/5
//        public IActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Activity activity = _persistanceWorker.Activities.GetOne(id);

//            if (activity == null)
//            {
//                return NotFound();
//            }

//            return View(activity);
//        }

//        // POST: Activities/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(string id)
//        {
//            Activity activity = _persistanceWorker.Activities.GetOne(id);
//            activity.IsDeleted = true;
//            _persistanceWorker.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }*/
//    }
//}
