using AutoMapper;
using NHibernateTest.Converters;
using NHibernateTest.Domain.Entities;
using NHibernateTest.Models;

namespace NHibernateTest
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Product, ProductViewModel>().ForMember(dest => dest.StoreId,
                    opt => opt.Ignore());
                config.CreateMap<Employee, EmployeeViewModel>();

                config.CreateMap<ProductViewModel, Product>()
                .ConvertUsing<ProductVMToProductConverter>();
                config.CreateMap<EmployeeViewModel, Employee>()
                .ConvertUsing<EmployeeVMToEmployeeConverter>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}