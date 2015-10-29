using NHibernateTest.Domain.Entities;
using System.Linq;

namespace NHibernateTest.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        void Create(T entity);

        void Delete(int id);

        IQueryable<T> GetAll();

        T GetById(int id);

        void Update(T entity);
    }
}