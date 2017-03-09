using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    using System.Threading.Tasks;

    using Business.Commands;
    using Business.Sdk;

    using Contracts;

    using FizzWare.NBuilder;

    using HSEModel;

    using Infrastructure;

    public partial class HighPotentialIncidentController : Controller
    {

        // GET: api/HighPotentialIncident
        public virtual async Task<ActionResult> CreateRandom()
        {
            //this.ExecuteCommand(command).OnSuccess(GoToUrl).OnError(GoToView)
            SubmitNewReportCommand<HighPotentialIncident> command = new SubmitNewReportCommand<HighPotentialIncident>();
            command.DomainObject = this.CreateValidHighPotentialIncident();
            command.ExecutingUser = this.User;

            CommandResult commandResult = await 
               InfrastructureContext.Bus.RequestAsync<SubmitNewReportCommand<HighPotentialIncident>, CommandResult>(command).ConfigureAwait(false);
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