using NHibernateTest.Domain.Entities;
using NHibernateTest.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NHibernateTest.Domain.Services
{
    public interface IProductService
    {
        void Create(Product product);

        void CreateForStore(Product product, int storeId);

        void Delete(int id);

        IList<Product> GetAll();

        Product GetById(int id);

        void Update(Product product);
    }

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Store> _storeRepository;

        public ProductService(IRepository<Product> productRepository,
            IRepository<Store> storeRepository)
        {
            _productRepository = productRepository;
            _storeRepository = storeRepository;
        }

        public void Create(Product product)
        {
            _productRepository.Create(product);
        }

        public void CreateForStore(Product product, int storeId)
        {
            var store = _storeRepository.GetById(storeId);
            store.AddProduct(product);
            _storeRepository.Update(store);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IList<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}