using AutoMapper;
using NHibernateTest.Domain.Entities;
using NHibernateTest.Models;

namespace NHibernateTest.Converters
{
    public class ProductVMToProductConverter : ITypeConverter<ProductViewModel, Product>
    {
        public Product Convert(ResolutionContext context)
        {
            if (context.IsSourceValueNull || context.DestinationValue == null) return null;
            var src = (ProductViewModel)context.SourceValue;
            var dst = (Product)context.DestinationValue;
            dst.Name = src.Name;
            dst.Price = src.Price;
            return dst;
        }
    }
}