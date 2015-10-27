using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using NHibernate.App_Start;
using Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(NHibernate.Startup))]
namespace NHibernate
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
