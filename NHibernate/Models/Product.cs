using System.Collections.Generic;

namespace NHibernateTest.Models
{
    public class Product
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