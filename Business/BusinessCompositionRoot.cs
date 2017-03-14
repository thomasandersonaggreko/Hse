using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    using Business.Commands;
    using Business.Events;
    using Business.Queries;
    using Business.Sdk;

    using Contracts;

    using Data;

    using HSEModel;
    using HSEModel.ReadModel;

    using Infrastructure.DateTime;
    using Infrastructure.MessageBus;

    using LightInject;
    using LightInject.Interception;

    /// <summary>
    /// The business composition root.
    /// </summary>
    public class BusinessCompositionRoot : ICompositionRoot
    {
        /// <summary>
        /// Composes services by adding services to the <paramref name="serviceRegistry" />.
        /// </summary>
        /// <param name="serviceRegistry">The target <see cref="T:LightInject.IServiceRegistry" />.</param>
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IStartup, NoSqlStartup>();
            serviceRegistry.Register<IDatamapper, NoSqlDatamapper>();

            serviceRegistry.Register<IReferenceNumberGenerator, ReferenceNumberGenerator>();
            serviceRegistry.Register<INotifier, Notifier>();

            serviceRegistry.Register<IDateTimeProvider, DateTimeProvider>();

            serviceRegistry.Register<IBusinessContextFactory, BusinessContextFactory>(new PerContainerLifetime());

            serviceRegistry.Register(typeof(IRequestHandler<,>), typeof(SubmitNewReportCommandHandler<>));
            serviceRegistry.Register(typeof(IRequestHandler<MonthlyHighPotentialIncidentReportQuery, QueryResult<MonthlyHighPotentialIncidents>>), typeof(MonthlyHighPotentialIncidentReportQueryHandler));
            serviceRegistry.Register<INotificationHandler<NewReportSubmittedEvent<HighPotentialIncident>>, NewReportSubmittedEventHandler>();
            serviceRegistry.Intercept(sr => sr.ServiceType == typeof(IRequestHandler<MonthlyHighPotentialIncidentReportQuery, QueryResult<MonthlyHighPotentialIncidents>>), factory => factory.GetInstance<IInterceptor>());
        }
    }
}
