using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernateTest.Domain.Entities;

namespace NHibernateTest.DAL.MappingOverrides
{
    public class StoreOverrides : IAutoMappingOverride<Store>
    {
        public void Override(AutoMapping<Store> mapping)
        {
            mapping.HasMany(x => x.Staff)
                .Inverse()
                .Cascade.All();
            mapping.HasManyToMany(x => x.Products)
                .Cascade.All()
                .Table("StoreProduct");
        }
    }
}