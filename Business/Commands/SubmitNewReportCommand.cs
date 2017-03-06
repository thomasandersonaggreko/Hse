﻿using MessageBus;

namespace Business.Commands
{
    using System.Security.Principal;

    using Business.Sdk;

    /// <summary>
    /// The submit new report command.
    /// </summary>
    /// <typeparam name="TObject">The domain object
    /// </typeparam>
    public class SubmitNewReportCommand<TObject> : Command, INotification
    {
        /// <summary>
        /// Gets or sets the domain object.
        /// </summary>
        /// <value>
        /// The domain object.
        /// </value>
        public TObject DomainObject { get; set; }
    }
}