using FluentNHibernate.Automapping;
using NHibernateTest.Domain.Entities;
using System;

namespace NHibernateTest.DAL.Helpers
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterface(typeof(IEntity).FullName) != null;
        }
    }
}