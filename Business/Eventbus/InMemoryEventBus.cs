using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Eventbus
{
    using System.Threading.Tasks.Dataflow;

    using Contracts;

    using LightInject;

    public class InMemoryEventBus : IEventBus
    {
        private ActionBlock<Tuple<Type, object>> queue;

        private IServiceContainer container;

        private IEventHandlerFactory eventHandlerFactory;

        public InMemoryEventBus()
        {
            this.container = new ServiceContainer();
            this.queue = new ActionBlock<Tuple<Type, object>>(x => this.ProcessEvent(x));
        }
        public void Publish<T>(BusinessEvent<T> businessEvent) where T : DomainObject
        {
            this.queue.Post(new Tuple<Type, object>(typeof(IEventHandler<BusinessEvent<T>>), businessEvent));
        }

        public void Subscribe<T>(IEventHandler<T> handler)
        {
           // this.container.r
            this.container.RegisterInstance(handler, $"{"EventHandler"}_{typeof(T).Name}");
            this.container.RegisterInstance(typeof(IEventHandler<T>), handler);
            this.container.RegisterInstance(handler.GetType(), handler);
        }

        private void ProcessEvent(Tuple<Type, object> item)
        {
            //dynamic d = @event;
            Type generic = typeof(IEventHandler<>);
            Type[] typeArgs = { item.Item2.GetType() };
            Type constructed = generic.MakeGenericType(typeArgs);
            //this.eventHandlerFactory.Resolve<T>();
            this.container.GetInstance(constructed, $"{"EventHandler"}_{item.GetType().Name}");
           
            var handlers = this.container.GetAllInstances(item.Item1).ToList();
        }

    }

    public interface IEventHandlerFactory
    {
        IEventHandler<T> Resolve<T>();
    }
}
