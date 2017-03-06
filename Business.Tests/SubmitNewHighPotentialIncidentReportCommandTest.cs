using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Business.Events;
using Business.Sdk;
using FizzWare.NBuilder;
using FluentAssertions;
using MessageBus;
using Moq;

namespace Business.Tests
{
    using Business.Commands;

    using Contracts;

    using HSEModel;

    using NUnit.Framework;

    [TestFixture]
    public class SubmitNewHighPotentialIncidentReportCommandTest
    {
        Moq.Mock<IReferenceNumberGenerator> referenceNumberGenerator = new Mock<IReferenceNumberGenerator>();
        Moq.Mock<IPrincipal> user = new Mock<IPrincipal>();
        Moq.Mock<IIdentity> identify = new Mock<IIdentity>();
        Moq.Mock<IDatamapper> datastore = new Mock<IDatamapper>();
        Moq.Mock<IBus> bus = new Mock<IBus>();
        Moq.Mock<INotifier> notifier = new Mock<INotifier>();
        Moq.Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>();
        DateTime currentDateTime = new DateTime(2017, 2, 2, 5, 45, 23);
        private string testReferenceNumber = "INC-2017-12345";

        [Test]
        public async Task Submit_A_Valid_High_Potential_Incident_Report()
        {
            //ARRANAGE
            SetupTestUser();
            SetupDateTimeProvider();
            SetupReferenceNumberGenerator();

            SubmitNewReportCommandHandler<HighPotentialIncident> handler = new SubmitNewReportCommandHandler<HighPotentialIncident>(datastore.Object, notifier.Object, dateTimeProvider.Object, this.referenceNumberGenerator.Object, bus.Object);
                SubmitNewReportCommand<HighPotentialIncident> command = new SubmitNewReportCommand<HighPotentialIncident>();
            command.ExecutingUser = this.user.Object;
            HighPotentialIncident domainObject = this.CreateValidHighPotentialIncident();
            command.DomainObject = domainObject;

            //            //ACT
            CommandResult commandResult = await handler.HandleAsync(command);

            //            //ASSERT
            commandResult.CommandResultReason.Should().Be(CommandResultReason.Successful);
            domainObject.Created.Should().Be(currentDateTime);
            domainObject.ReferenceNumber.Should().Be(this.testReferenceNumber);
            datastore.Verify(x => x.SaveAsync(domainObject), Times.Once);
            notifier.Verify(x => x.Notify(It.IsAny<NewReportSubmittedEvent<HighPotentialIncident>>()), Times.Once);
        }

        private HighPotentialIncident CreateValidHighPotentialIncident()
        {
            return FizzWare.NBuilder.Builder<HighPotentialIncident>.CreateNew()
                .With(x => x.ActualLoss, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                 .With(x => x.PrimaryDesc, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                  .With(x => x.PotentialLoss, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                   .With(x => x.AtFaultId, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                   .With(x => x.LocationType, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                   .With(x => x.OtherPrimaryType, null)
                .Build();
        }

        private void SetupDateTimeProvider()
        {
            dateTimeProvider.Setup(x => x.Now).Returns(currentDateTime);
        }

        private void SetupTestUser()
        {

            user.Setup(x => x.Identity).Returns(identify.Object);
            identify.Setup(x => x.Name).Returns("Test User");
        }

        private void SetupReferenceNumberGenerator()
        {
            referenceNumberGenerator.Setup(x => x.Generate()).Returns(testReferenceNumber);
        }
    }
}
