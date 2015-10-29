namespace NHibernateTest.Domain.Helpers
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();
    }
}