using Microsoft.Owin;
using Microsoft.Practices.Unity.Mvc;
using Owin;
using System.Linq;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(NHibernateTest.Startup))]

namespace NHibernateTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            ConfigureAuth(app);
        }
    }
}