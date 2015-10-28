using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Models;
using NHibernate.Tool.hbm2ddl;
using NHibernateTest.DAL.Models;

namespace NHibernate.App_Start
{
    public class NHibernateConfig
    {
        public static ISessionFactory CreateSessionFactory(bool createSchema = false)
        {
            return GetConfiguration().BuildSessionFactory();
        }

        private static FluentConfiguration GetConfiguration()
        {
            // this assumes you are using the default Identity model of "ApplicationUser"
            var myEntities = new[] {
                typeof(ApplicationUser)
            };

            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                    //c => c.FromAppSetting("connectionString")
                    @"Data Source=ADWA;Initial Catalog=test;Integrated Security=True"
                    ))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Store>())
                .ExposeConfiguration(cfg =>
                {
                    cfg.AddDeserializedMapping(
                        MappingHelper.GetIdentityMappings(myEntities), null);
                    /* Generacja początkowej struktury bazy

                    new SchemaExport(cfg)
                    .Create(false, true);
                    */
                    new SchemaUpdate(cfg).Execute(false, true);
                });
            return configuration;
        }
    }
}