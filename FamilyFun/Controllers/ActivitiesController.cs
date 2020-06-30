//using FamilyFun.Persistance;

//namespace FamilyFun.Web.Controllers
//{
//    public class ActivitiesController : BaseController<string>
//    {
//        public ActivitiesController(UnitOfWork persistanceWorker) : base(persistanceWorker)
//        {
//           // _persistanceWorker = persistanceWorker ?? throw new ArgumentNullException(nameof(persistanceWorker));
//        }
//        /*
//        // GET: Activities
//        public IActionResult Index()
//        {
//            return View(_persistanceWorker.Activities.GetAll());
//        }
        
//        // GET: Activities/Details/5
//        public IActionResult Details(string id)
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

//        // GET: Activities/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Activities/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create([Bind("Name,Points")] Activity activity)
//        {
//            if (ModelState.IsValid)
//            {
//                _persistanceWorker.Activities.Insert(activity);
//                _persistanceWorker.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(activity);
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

//                if(existingActivity is null)
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
