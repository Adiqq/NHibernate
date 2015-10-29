using NHibernateTest.Domain.Entities;
using NHibernateTest.Domain.Services;
using System;
using System.Web.Mvc;

namespace NHibernateTest.Controllers
{
    public class StoreController : BaseController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
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
                _storeService.Create(model);
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
            var result = _storeService.GetById(id);
            return View(result);
        }

        // POST: Store/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Store model)
        {
            try
            {
                _storeService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            var result = _storeService.GetEagerById(id);
            return View(result);
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _storeService.GetById(id);
            return View(result);
        }

        // POST: Store/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Store model)
        {
            try
            {
                var store = _storeService.GetById(id);
                store.Name = model.Name;
                _storeService.Update(store);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Store
        public ActionResult Index()
        {
            var stores = _storeService.GetAll();
            return View(stores);
        }
    }
}