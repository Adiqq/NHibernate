using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernateTest.Domain.Entities;

namespace NHibernateTest.Data.MappingOverrides
{
    public class ProductOverrides : IAutoMappingOverride<Product>
    {
        public void Override(AutoMapping<Product> mapping)
        {
            mapping.HasManyToMany(x => x.StoresStockedIn)
                .Cascade.All()
                .Inverse()
                .Table("StoreProduct");
        }
    }
}