using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Web
{
    using System.Collections;

    using Business;
    using Business.Commands;
    using Business.Queries;

    using Contracts;

    using HSEModel;

    using Infrastructure.MessageBus;

    using LightInject;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new ServiceContainer();
            container.RegisterControllers();
            container.RegisterFrom<BusinessCompositionRoot>();
            container.Register<IBus, InMemoryBus>();
            container.Register<IHandlerFactory, HandlerFactory>();

            container.RegisterInstance(typeof(IServiceContainer), container);
            //container.Register<INotifier, Notifier>();
            
            //container.Register<IDateTimeProvider, DateTimeProvider>();
            //container.Register<IReferenceNumberGenerator, ReferenceNumberGenerator>();
            //container.Register<SubmitNewReportCommand<HighPotentialIncident>>();
            //container.Register<ReportListViewQuery>();

            //container.Register<ICommandFactory, CommandFactory>(new PerContainerLifetime());
            //container.Register<IQueryFactory, QueryFactory>(new PerContainerLifetime());

            //register other services

            container.EnableMvc();

            IEnumerable<IStartup> startups = container.GetAllInstances<IStartup>();

            foreach (IStartup startup in startups)
            {
                startup.Start();
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
