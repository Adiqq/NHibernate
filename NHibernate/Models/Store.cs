using System.Collections.Generic;

namespace NHibernateTest.Models
{
    public class Store
    {
        public Store()
        {
            Products = new List<Product>();
            Staff = new List<Employee>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<Employee> Staff { get; set; }

        public virtual void AddEmployee(Employee employee)
        {
            employee.Store = this;
            Staff.Add(employee);
        }

        public virtual void AddProduct(Product product)
        {
            product.StoresStockedIn.Add(this);
            Products.Add(product);
        }
    }
}