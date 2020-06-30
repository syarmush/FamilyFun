//using System;
//using Microsoft.AspNetCore.Mvc;
//using FamilyFun.Persistance;

//namespace FamilyFun.Web.Controllers
//{
//    public class BaseController<T> : Controller
//    {
//        protected readonly UnitOfWork _persistanceWorker;

//        public BaseController(UnitOfWork persistanceWorker)
//        {
//            _persistanceWorker = persistanceWorker ?? throw new ArgumentNullException(nameof(persistanceWorker));
//        }

//        // GET: Activities
//        public IActionResult Index()
//        {
//            return View(_persistanceWorker.Repository<T>().GetAllAsync());
//        }

//        // GET: Activities/Details/5
//        public IActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            T activity = _persistanceWorker.Repository<T>().GetOneAsync(id);

//            if (activity == null)
//            {
//                return NotFound();
//            }

//            return View(activity);
//        }

//        // GET: Activities/Create
//        public virtual IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Activities/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public virtual IActionResult Create(T entity)
//        {
//            if (ModelState.IsValid)
//            {
//                _persistanceWorker.Repository<T>().InsertAsync(entity);
//                _persistanceWorker.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(entity);
//        }

//        // GET: Activities/Edit/5
//        public IActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            T activity = _persistanceWorker.Repository<T>().GetOneAsync(id);

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
//        public IActionResult Edit(string id, T entity)
//        {
//            if (id != entity.ToString())
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                T existingActivity = _persistanceWorker.Repository<T>().GetOneAsync(id);

//                if(existingActivity is null)
//                {
//                    return NotFound();
//                }

//                _persistanceWorker.Repository<T>().UpdateAsync(entity);
//                _persistanceWorker.SaveChanges();

//                return RedirectToAction(nameof(Index));
//            }
//            return View(entity);
//        }

//        // GET: Activities/Delete/5
//        public IActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            T entity = _persistanceWorker.Repository<T>().GetOneAsync(id);

//            if (entity == null)
//            {
//                return NotFound();
//            }

//            return View(entity);
//        }

//        // POST: Activities/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(string id)
//        {
//            T entity = _persistanceWorker.Repository<T>().GetOneAsync(id);
//            //entity.IsDeleted = true;
//            _persistanceWorker.Repository<T>().UpdateAsync(entity);
//            _persistanceWorker.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
