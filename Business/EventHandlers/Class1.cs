﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EventHandlers
{
    using Business.Commands;

    using Contracts;

    using HSEModel;

    public class NewReportSubmittedEventHandler : IEventHandler<SubmitNewReportCommand<HighPotentialIncident>>
    {
        public void Handle(SubmitNewReportCommand<HighPotentialIncident> @event)
        {
            throw new NotImplementedException();
        }
    }
}
