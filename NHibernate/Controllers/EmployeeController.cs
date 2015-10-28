using NHibernate;
using NHibernateTest.DAL.Models;
using NHibernateTest.ViewModels;
using System.Web.Mvc;

namespace NHibernateTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ISession _session;

        public EmployeeController(ISession session)
        {
            _session = session;
        }

        // GET: Employee/Create
        public ActionResult Create(int parentId)
        {
            var model = new EmployeeViewModel { StoreId = parentId };
            return View(model);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    var store = _session.QueryOver<Store>().Where(x => x.Id == model.StoreId).SingleOrDefault();
                    var employee = new Employee
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };
                    store.AddEmployee(employee);
                    _session.SaveOrUpdate(store);
                    transaction.Commit();
                    return RedirectToAction("Index", "Store", new { id = model.Id });
                }
            }
            else
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _session.QueryOver<Employee>().Where(x => x.Id == id).SingleOrDefault();
            var viewModel = new EmployeeViewModel() { FirstName = model.FirstName, Id = id, LastName = model.LastName, StoreId = model.Store.Id };
            return View(viewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeViewModel model)
        {
            try
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Delete(id);
                    transaction.Commit();

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var model = _session.QueryOver<Employee>().Where(x => x.Id == id).SingleOrDefault();
            var viewModel = new EmployeeViewModel() { FirstName = model.FirstName, Id = id, LastName = model.LastName, StoreId = model.Store.Id };
            return View(viewModel);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _session.QueryOver<Employee>().Where(x => x.Id == id).SingleOrDefault();
            var viewModel = new EmployeeViewModel() { FirstName = model.FirstName, Id = id, LastName = model.LastName, StoreId = model.Store.Id };
            return View(viewModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _session.QueryOver<Employee>().Where(x => x.Id == id).SingleOrDefault();
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                _session.SaveOrUpdate(employee);
                return RedirectToAction("Details", "Store", new { id = model.Id });
            }
            else
            {
                return View();
            }
        }
    }
}