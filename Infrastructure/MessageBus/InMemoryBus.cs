namespace Infrastructure.MessageBus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Infrastructure.Logging;
    using Infrastructure.Validation;

    using LightInject;

    public interface IHandlerFactory
    {
        IRequestHandler<T> GetInstance<T>(Type type) where T : IRequest; //where T : IRequest<T>;

        IRequestHandler<T, TR> GetInstance<T, TR>(Type type) where T : IRequest, IRequest<TR>; //where T : IRequest<T>;

        IEnumerable<T> GetAllInstances<T>();
    }

    public class HandlerFactory : IHandlerFactory
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILogger Logger = InfrastructureContext.LogManager.GetLogger<HandlerFactory>();
        private IServiceContainer container;

        public HandlerFactory(IServiceContainer container)
        {
            this.container = container;
        }

        public IRequestHandler<T> GetInstance<T>(Type type) where T : IRequest
        {
            return null;//this.container.GetInstance(type);
        }

        public IRequestHandler<T, TR> GetInstance<T, TR>(Type type) where T : IRequest, IRequest<TR>
        {
            //TODO add some logging
            return this.container.TryGetInstance<IRequestHandler<T, TR>>();
        }

        public IEnumerable<T> GetAllInstances<T>()
        {
            //TODO add some logging
            return this.container.GetAllInstances<T>();
        }
    }

    /// <summary>
    /// Default mediator implementation relying on single- and multi instance delegates for resolving handlers.
    /// </summary>
    public class InMemoryBus : IBus
    {
        /// <summary>
        /// The handler factory
        /// </summary>
        private readonly IHandlerFactory handlerFactory;

        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILogger Logger = InfrastructureContext.LogManager.GetLogger<InMemoryBus>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryBus"/> class. 
        /// </summary>
        public InMemoryBus(IHandlerFactory handlerFactory)
        {
            this.handlerFactory = handlerFactory;
        }

        /// <summary>
        /// Asynchronously send a request to a single handler
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="request">Request object</param>
        /// <returns>
        /// A task that represents the send operation. The task result contains the handler response
        /// </returns>
        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest, IRequest<TResponse>
        {
            IRequestHandler<TRequest, TResponse> handler = this.handlerFactory.GetInstance<TRequest, TResponse>(typeof(TRequest));
            return handler.HandleAsync(request);
        }

        /// <summary>
        /// The publish async.
        /// </summary>
        /// <param name="notification">
        /// The notification.
        /// </param>
        /// <typeparam name="TNotification">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task PublishAsync<TNotification>(TNotification notification) where TNotification : INotification
        {
            IEnumerable<INotificationHandler<TNotification>> handlers = this.handlerFactory.GetAllInstances<INotificationHandler<TNotification>>();
            return Task.WhenAll(handlers.Select(x => x.HandleAsync(notification)));
        }
    }
}