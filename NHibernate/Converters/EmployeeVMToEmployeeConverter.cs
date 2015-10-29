using AutoMapper;
using NHibernateTest.Domain.Entities;
using NHibernateTest.Models;

namespace NHibernateTest.Converters
{
    public class EmployeeVMToEmployeeConverter : ITypeConverter<EmployeeViewModel, Employee>
    {
        public Employee Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull || context.DestinationValue == null) return null;
            var src = (EmployeeViewModel)context.SourceValue;
            var dst = (Employee)context.DestinationValue;
            dst.FirstName = src.FirstName;
            dst.LastName = src.LastName;
            return dst;
        }
    }
}