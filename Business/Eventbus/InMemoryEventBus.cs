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
            this.container.RegisterInstance(handler, typeof(T).FullName);
            this.container.RegisterInstance(typeof(IEventHandler<T>), handler);
            this.container.RegisterInstance(handler.GetType(), handler);
        }

        private void ProcessEvent(Tuple<Type, object> item)
        {
            //dynamic d = @event;
            //Type generic = typeof(IEventHandler<>);
            //Type[] typeArgs = { d.GetType() };
            //Type constructed = generic.MakeGenericType(d);

            this.container.GetInstance(item.Item1, item.Item1.FullName);
           
            var handlers = this.container.GetAllInstances(item.Item1).ToList();
        }

    }
}
