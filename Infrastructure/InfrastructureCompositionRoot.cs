namespace Infrastructure
{
    using Contracts;

    using Infrastructure.DateTime;
    using Infrastructure.Interceptor;
    using Infrastructure.Logging;
    using Infrastructure.MessageBus;
    using Infrastructure.Validation;

    using LightInject;
    using LightInject.Interception;

    /// <summary>
    /// The business composition root.
    /// </summary>
    public class InfrastructureCompositionRoot : ICompositionRoot
    {
        /// <summary>
        /// Composes services by adding services to the <paramref name="serviceRegistry" />.
        /// </summary>
        /// <param name="serviceRegistry">The target <see cref="T:LightInject.IServiceRegistry" />.</param>
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IBus, InMemoryBus>(new PerContainerLifetime());
            serviceRegistry.Register<IValidator, DataAnnotationValidator>(new PerContainerLifetime());
            serviceRegistry.Register<IHandlerFactory, HandlerFactory>(new PerContainerLifetime());
            serviceRegistry.Register<ILogManager, LogManager>(new PerContainerLifetime());
            serviceRegistry.Register<IDateTimeProvider, DateTimeProvider>(new PerContainerLifetime());
            serviceRegistry.Register<IInfrastructureContextFactory, InfrastructureContextFactory>(new PerContainerLifetime());

            serviceRegistry.Register<IInterceptor, LoggingInterceptor>();
            serviceRegistry.Decorate<IInterceptor, LoggingAsyncInterceptor>();
        }
    }
}
