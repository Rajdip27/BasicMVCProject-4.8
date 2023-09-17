using Autofac;
using Autofac.Integration.Mvc;
using BankSolution.Models;
using BankSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace BankSolution
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();

            RegisterApplicationServices(builder);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterApplicationServices(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UserServices>().AsImplementedInterfaces().AsSelf().InstancePerRequest();
        }
    }
}
