using NHibernate;
using NHibernateTest.Models;
using System.Web.Mvc;

namespace NHibernateTest.Controllers
{
    public class StoreController : Controller
    {
        private readonly ISession _session;

        public StoreController(ISession session)
        {
            _session = session;
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(Store model)
        {
            if (ModelState.IsValid)
            {
                _session.SaveOrUpdate(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _session.QueryOver<Store>().
                Where(x => x.Id == id).SingleOrDefault();
            return View(result);
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Store model)
        {
            try
            {
                // TODO: Add delete logic here
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(model);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            var result = _session.QueryOver<Store>().
                Where(x => x.Id == id).SingleOrDefault();
            return View(result);
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _session.QueryOver<Store>().
                Where(x => x.Id == id).SingleOrDefault();
            return View(result);
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Store model)
        {
            try
            {
                // TODO: Add update logic here
                _session.SaveOrUpdate(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store
        public ActionResult Index()
        {
            var stores = _session.QueryOver<Store>().List();
            return View(stores);
        }
    }
}