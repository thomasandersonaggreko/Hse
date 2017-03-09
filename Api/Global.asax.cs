using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Api
{
    using Business;

    using Contracts;

    using Infrastructure;
    using Infrastructure.MessageBus;

    using LightInject;

    /// <summary>
    /// The web API application.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Applications the start.
        /// </summary>
        protected void Application_Start()
        {
            var container = new ServiceContainer();
            container.RegisterApiControllers();

            // register other services
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
            container.SetupInfrastructureContext();
            container.SetupBusinessContext();
            container.RunStartup();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
