using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernateTest.Domain.Entities;

namespace NHibernateTest.DAL.MappingOverrides
{
    public class EmployeeOverrides : IAutoMappingOverride<Employee>
    {
        public void Override(AutoMapping<Employee> mapping)
        {
        }
    }
}