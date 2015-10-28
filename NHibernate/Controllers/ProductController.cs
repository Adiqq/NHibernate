using NHibernate;
using NHibernateTest.Models;
using NHibernateTest.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace NHibernateTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISession _session;

        public ProductController(ISession session)
        {
            _session = session;
        }

        // GET: Product/Create
        public ActionResult Create(int parentId = 0)
        {
            var model = new ProductViewModel { StoreId = parentId };
            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    var product = new Product() { Name = model.Name, Price = model.Price };

                    if (model.StoreId != 0)
                    {
                        var store = _session.QueryOver<Store>().Where(x => x.Id == model.StoreId).SingleOrDefault();
                        store.AddProduct(product);
                        _session.SaveOrUpdate(store);
                    }
                    else
                    {
                        _session.SaveOrUpdate(product);
                    }
                    transaction.Commit();

                    if (model.StoreId != 0)
                    {
                        return RedirectToAction("Details", "Store", new { id = model.StoreId });
                    }
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _session.QueryOver<Product>().Where(x => x.Id == id).SingleOrDefault();
            var viewModel = new ProductViewModel { Id = product.Id, Name = product.Name, Price = product.Price };
            return View(viewModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
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

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = _session.QueryOver<Product>().Where(x => x.Id == id).SingleOrDefault();
            var viewModel = new ProductViewModel { Id = product.Id, Name = product.Name, Price = product.Price };
            return View(viewModel);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _session.QueryOver<Product>().Where(x => x.Id == id).SingleOrDefault();
            var viewModel = new ProductViewModel { Id = product.Id, Name = product.Name, Price = product.Price };
            return View(viewModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _session.QueryOver<Product>().Where(x => x.Id == id).SingleOrDefault();
                product.Name = model.Name;
                product.Price = model.Price;
                _session.SaveOrUpdate(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            var products = _session.QueryOver<Product>().List();
            var viewmodels = products.Select(x => new ProductViewModel { Id = x.Id, Name = x.Name, Price = x.Price });
            return View(viewmodels);
        }
    }
}