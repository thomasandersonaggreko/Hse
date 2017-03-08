using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    using Business.Commands;

    using Contracts;

    using Data;

    using Infrastructure.DateTime;
    using Infrastructure.MessageBus;

    using LightInject;

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
            serviceRegistry.Register<IDatastore, NoSqlDataStore>();

            serviceRegistry.Register<IReferenceNumberGenerator, ReferenceNumberGenerator>();
            serviceRegistry.Register<INotifier, Notifier>();

            serviceRegistry.Register<IDateTimeProvider, DateTimeProvider>();

            serviceRegistry.Register(typeof(IRequestHandler<,>), typeof(SubmitNewReportCommandHandler<>));
        }
    }
}
