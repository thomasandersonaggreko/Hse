namespace Business.Eventbus
{
    using System;
    using System.Linq;
    using System.Threading.Tasks.Dataflow;

    using Contracts;

    using LightInject;

    /// <summary>
    /// The in memory event bus.
    /// </summary>
    public class InMemoryEventBus : IEventBus
    {
        /// <summary>
        /// The container
        /// </summary>
        private IServiceContainer container;

        /// <summary>
        /// The event handler factory
        /// </summary>
        private IEventHandlerFactory eventHandlerFactory;

        /// <summary>
        /// The queue
        /// </summary>
        private ActionBlock<Tuple<Type, object>> queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryEventBus"/> class.
        /// </summary>
        public InMemoryEventBus()
        {
            this.container = new ServiceContainer();
            this.queue = new ActionBlock<Tuple<Type, object>>(x => this.ProcessEvent(x));
        }

        /// <summary>
        /// Publishes the specified business event.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="businessEvent">The business event.</param>
        public void Publish<T>(BusinessEvent<T> businessEvent) where T : DomainObject
        {
            this.queue.Post(new Tuple<Type, object>(typeof(IEventHandler<BusinessEvent<T>>), businessEvent));
        }

        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="T">The command type</typeparam>
        /// <param name="handler">The handler.</param>
        public void Subscribe<T>(IEventHandler<T> handler)
        {
            // this.container.r
            this.container.RegisterInstance(handler, $"{"EventHandler"}_{typeof(T).Name}");
            this.container.RegisterInstance(typeof(IEventHandler<T>), handler);
            this.container.RegisterInstance(handler.GetType(), handler);
        }

        /// <summary>
        /// Processes the event.
        /// </summary>
        /// <param name="item">The item.</param>
        private void ProcessEvent(Tuple<Type, object> item)
        {
            // dynamic d = @event;
            Type generic = typeof(IEventHandler<>);
            Type[] typeArgs = { item.Item2.GetType() };
            Type constructed = generic.MakeGenericType(typeArgs);

            // this.eventHandlerFactory.Resolve<T>();
            this.container.GetInstance(constructed, $"{"EventHandler"}_{item.GetType().Name}");

            var handlers = this.container.GetAllInstances(item.Item1).ToList();
        }
    }
}