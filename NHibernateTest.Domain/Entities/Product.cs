using System.Collections.Generic;

namespace NHibernateTest.Domain.Entities
{
    public class Product : IEntity
    {
        public Product()
        {
            StoresStockedIn = new List<Store>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual IList<Store> StoresStockedIn { get; set; }
    }
}