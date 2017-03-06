namespace Business.Sdk
{
    using System.Security.Principal;

    using Business.Commands;

    using MessageBus;

    /// <summary>
    /// The command request.
    /// </summary>
    public class Command : IRequest<CommandResult>
    {
        /// <summary>
        /// Gets or sets the executing user.
        /// </summary>
        /// <value>
        /// The executing user.
        /// </value>
        public IPrincipal ExecutingUser { get; set; }
    }
}