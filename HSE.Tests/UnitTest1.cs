//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace HSE.Tests
//{
//    using System.Security.Principal;

//    using Business.Commands;

//    using Contracts;

//    using FizzWare.NBuilder;

//    using FluentAssertions;

//    using HSEModel;
//    using HSEModel.Commands;

//    using Moq;
    

//    [TestClass]
//    public class UnitTest1
//    {
//        Moq.Mock<IReferenceNumberGenerator> referenceNumberGenerator = new Mock<IReferenceNumberGenerator>();
//        Moq.Mock<IPrincipal> user = new Mock<IPrincipal>();
//        Moq.Mock<IIdentity> identify = new Mock<IIdentity>();
//        Moq.Mock<IDatamapper> datastore = new Mock<IDatamapper>();
//        Moq.Mock<INotifier> notifier = new Mock<INotifier>();
//        Moq.Mock<IDateTimeProvider> dateTimeProvider = new Mock<IDateTimeProvider>();
//        DateTime currentDateTime = new DateTime(2017, 2, 2, 5, 45, 23);

//        private string testReferenceNumber = "INC-2017-12345";

//        [TestMethod]
//        public void Submit_A_Valid_High_Potential_Incident_Report()
//        {
//            //ARRANAGE
//            SetupTestUser();
//            SetupDateTimeProvider();
//            SetupReferenceNumberGenerator();


//            SubmitNewReportCommand<HighPotentialIncident> command  = new SubmitNewReportCommand<HighPotentialIncident>(datastore.Object, notifier.Object, dateTimeProvider.Object, this.referenceNumberGenerator.Object);
//            HighPotentialIncident domainObject = this.CreateValidHighPotentialIncident();
//            command.DomainObject = domainObject;

//            //ACT
//            CommandResult commandResult = command.Execute(user.Object);

//            //ASSERT
//            commandResult.CommandResultReason.Should().Be(CommandResultReason.Successful);
//            domainObject.Created.Should().Be(currentDateTime);
//            domainObject.ReferenceNumber.Should().Be(this.testReferenceNumber);
//            datastore.Verify(x => x.Save(domainObject), Times.Once);
//            notifier.Verify(x => x.Notify(It.IsAny<NewReportSubmittedEvent<HighPotentialIncident>>()), Times.Once);
//        }

//        private HighPotentialIncident CreateValidHighPotentialIncident()
//        {
//            return FizzWare.NBuilder.Builder<HighPotentialIncident>.CreateNew()
//                .With(x => x.ActualLoss, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
//                 .With(x => x.PrimaryDesc, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
//                  .With(x => x.PotentialLoss, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
//                   .With(x => x.AtFaultId, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
//                   .With(x => x.LocationType, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
//                   .With(x => x.OtherPrimaryType, null)
//                .Build();
//        }

//        private void SetupDateTimeProvider()
//        {
//            dateTimeProvider.Setup(x => x.Now).Returns(currentDateTime);
//        }

//        private void SetupTestUser()
//        {
            
//            user.Setup(x => x.Identity).Returns(identify.Object);
//            identify.Setup(x => x.Name).Returns("Test User");
//        }

//        private void SetupReferenceNumberGenerator()
//        {
//            referenceNumberGenerator.Setup(x => x.Generate()).Returns(testReferenceNumber);
//        }
//    }
//}
