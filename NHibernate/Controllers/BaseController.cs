using Microsoft.Practices.Unity;
using NHibernateTest.Domain.Helpers;
using System.Web.Mvc;

namespace NHibernateTest.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public IUnitOfWork UnitOfWork { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
                UnitOfWork.Commit();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
                UnitOfWork.BeginTransaction();
        }
    }
}