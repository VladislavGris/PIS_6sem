using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Web.Mvc;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var kernel = new StandardKernel(new DIConfig());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
