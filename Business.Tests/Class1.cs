using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    using Business.Commands;
    using Business.Eventbus;
    using Business.EventHandlers;

    using Contracts;

    using HSEModel;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void Test()
        {
            InMemoryEventBus eventBus = new InMemoryEventBus();
            eventBus.Subscribe(new NewReportSubmittedEventHandler());
            eventBus.Publish(new NewReportSubmittedEvent<HighPotentialIncident>());
        }
    }
}
