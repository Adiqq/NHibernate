using NHibernate;
using NHibernateTest.Domain.Entities;
using NHibernateTest.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NHibernateTest.Domain.Services
{
    public interface IStoreService
    {
        void Create(Store store);

        void Delete(int id);

        IList<Store> GetAll();

        Store GetById(int id);

        Store GetEagerById(int id);

        void Update(Store store);
    }

    public class StoreService : IStoreService
    {
        private readonly IRepository<Store> _storeRepository;

        public StoreService(IRepository<Store> storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public void Create(Store store)
        {
            _storeRepository.Create(store);
        }

        public void Delete(int id)
        {
            _storeRepository.Delete(id);
        }

        public IList<Store> GetAll()
        {
            return _storeRepository.GetAll().ToList();
        }

        public Store GetById(int id)
        {
            var entity = _storeRepository.GetById(id);
            return entity;
        }

        public Store GetEagerById(int id)
        {
            //eager load
            var entity = GetById(id);
            NHibernateUtil.Initialize(entity.Staff);
            NHibernateUtil.Initialize(entity.Products);
            return entity;
        }

        public void Update(Store store)
        {
            _storeRepository.Update(store);
        }
    }
}