using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using NHibernate.AspNet.Identity;
using NHibernateTest.Data.Helpers;
using NHibernateTest.Data.Repositories;
using NHibernateTest.Domain.Entities;
using NHibernateTest.Domain.Helpers;
using NHibernateTest.Domain.Repositories;
using NHibernateTest.Domain.Services;
using System;
using System.Reflection;
using System.Web;

namespace NHibernate.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        #endregion Unity Container

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUserStore<ApplicationUser>>(
    new InjectionFactory(x =>
    {
        return new UserStore<ApplicationUser>(new UnitOfWork().Session);
    }));
            container.RegisterType<ApplicationSignInManager>();
            container.RegisterType<ApplicationUserManager>();

            container.RegisterTypes(AllClasses.FromAssemblies(Assembly.GetAssembly(typeof(IProductService))), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.Transient);
        }
    }
}