using AutoMapper;
using NHibernateTest.Domain.Entities;
using NHibernateTest.Domain.Services;
using NHibernateTest.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NHibernateTest.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
                var product = Mapper.Map(model, new Product());

                if (model.StoreId != 0)
                {
                    _productService.CreateForStore(product, model.StoreId);
                    return RedirectToAction("Details", "Store", new { id = model.StoreId });
                }
                else
                {
                    _productService.Create(product);
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
            var product = _productService.GetById(id);
            var viewModel = Mapper.Map<ProductViewModel>(product);
            return View(viewModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductViewModel model)
        {
            try
            {
                _productService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            var viewModel = Mapper.Map<ProductViewModel>(product);
            return View(viewModel);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            var viewModel = Mapper.Map<ProductViewModel>(product);
            return View(viewModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetById(id);
                Mapper.Map(model, product);
                _productService.Update(product);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            var products = _productService.GetAll();
            var viewmodels = Mapper.Map<IList<ProductViewModel>>(products);
            return View(viewmodels);
        }
    }
}