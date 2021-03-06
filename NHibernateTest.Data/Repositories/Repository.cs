﻿using NHibernate;
using NHibernate.Linq;
using NHibernateTest.Data.Helpers;
using NHibernateTest.Domain.Entities;
using NHibernateTest.Domain.Helpers;
using NHibernateTest.Domain.Repositories;
using System.Linq;

namespace NHibernateTest.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly UnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public void Create(T entity)
        {
            Session.Save(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }
    }
}