using NHibernateTest.Domain.Entities;
using NHibernateTest.Domain.Services;
using NHibernateTest.Models;
using System.Web.Mvc;

namespace NHibernateTest.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
                var employee = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };
                _employeeService.CreateForStore(employee, model.StoreId);
                return RedirectToAction("Index", "Store", new { id = model.Id });
            }
            else
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _employeeService.GetById(id);
            var viewModel = new EmployeeViewModel() { FirstName = model.FirstName, Id = id, LastName = model.LastName, StoreId = model.Store.Id };
            return View(viewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeViewModel model)
        {
            try
            {
                _employeeService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var model = _employeeService.GetById(id);
            var viewModel = new EmployeeViewModel() { FirstName = model.FirstName, Id = id, LastName = model.LastName, StoreId = model.Store.Id };
            return View(viewModel);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _employeeService.GetById(id);
            var viewModel = new EmployeeViewModel() { FirstName = model.FirstName, Id = id, LastName = model.LastName, StoreId = model.Store.Id };
            return View(viewModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(id);
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                _employeeService.Update(employee);
                return RedirectToAction("Details", "Store", new { id = model.Id });
            }
            else
            {
                return View();
            }
        }
    }
}