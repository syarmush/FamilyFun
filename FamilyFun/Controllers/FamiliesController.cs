//using FamilyFun.Persistance;

//namespace FamilyFun.Web.Controllers
//{
//    public class FamiliesController : BaseController<string>
//    {
//        public FamiliesController(UnitOfWork persistanceWorker) : base(persistanceWorker)
//        {
//           // _persistanceWorker = persistanceWorker ?? throw new ArgumentNullException(nameof(persistanceWorker));
//        }
//        /*
//        // GET: Families
//        public IActionResult Index()
//        {
//            return View(_persistanceWorker.Families.GetAll());
//        }
        
//        // GET: Families/Details/5
//        public IActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Family family = _persistanceWorker.Families.GetOne(id);
//            if (family == null)
//            {
//                return NotFound();
//            }

//            return View(family);
//        }

//        // GET: Families/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Families/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create([Bind("FamilyName")] Family family)
//        {
//            if (ModelState.IsValid)
//            {
//                _persistanceWorker.Families.Insert(family);
//                _persistanceWorker.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(family);
//        }

//        // GET: Families/Edit/5
//        public IActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Family family = _persistanceWorker.Families.GetOne(id);
//            if (family == null)
//            {
//                return NotFound();
//            }

//            return View(family);
//        }

//        // POST: Families/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(string id, [Bind("FamilyName,Id")] Family family)
//        {
//            if (id != family.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                if (!_persistanceWorker.Families.Update(family))
//                {
//                    return NotFound();
//                }

//                return RedirectToAction(nameof(Index));
//            }
//            return View(family);
//        }

//        // GET: Families/Delete/5
//        public ActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Family family = _persistanceWorker.Families.GetOne(id);
//            if (family == null)
//            {
//                return NotFound();
//            }

//            return View(family);
//        }

//        // POST: Families/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(string id)
//        {
//            Family existingFamily = _persistanceWorker.Families.GetOne(id);
//            if (existingFamily == null)
//            {
//                return NotFound();
//            }

//            existingFamily.IsDeleted = true;
//            _persistanceWorker.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }*/
//    }
//}
