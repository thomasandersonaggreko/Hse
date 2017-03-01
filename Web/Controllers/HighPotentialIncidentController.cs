using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    using Business.Commands;

    using FizzWare.NBuilder;

    using HSEModel;

    public partial class HighPotentialIncidentController : Controller
    {
        private ICommandFactory commandFactory;

        public HighPotentialIncidentController(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }


        // GET: HighPotentialIncident
        public virtual ActionResult CreateRandom()
        {
            SubmitNewReportCommand<HighPotentialIncident> command =
                this.commandFactory.GetCommand<SubmitNewReportCommand<HighPotentialIncident>>();
            HighPotentialIncident domainObject = this.CreateValidHighPotentialIncident();
            command.DomainObject = domainObject;

            CommandResult commandResult = command.Execute(this.User);
            return View();
        }

        private HighPotentialIncident CreateValidHighPotentialIncident()
        {
            return Builder<HighPotentialIncident>.CreateNew()
                .With(x => x.ActualLoss, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                 .With(x => x.PrimaryDesc, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                  .With(x => x.PotentialLoss, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                   .With(x => x.AtFaultId, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                   .With(x => x.LocationType, FizzWare.NBuilder.Builder<ReferenceDataItem>.CreateNew().Build())
                .Build();
        }
    }
}