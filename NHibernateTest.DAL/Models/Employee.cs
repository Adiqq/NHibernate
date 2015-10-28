namespace NHibernateTest.DAL.Models
{
    public class Employee
    {
        public virtual string FirstName { get; set; }
        public virtual int Id { get; set; }
        public virtual string LastName { get; set; }
        public virtual Store Store { get; set; }
    }
}