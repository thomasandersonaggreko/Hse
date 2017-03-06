namespace Business.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Principal;
    using System.Threading.Tasks;

    using Business.Commands;

    using MessageBus;

    /// <summary>
    /// The command handler.
    /// </summary>
    /// <typeparam name="TRquest">The request type
    /// </typeparam>
    public abstract class CommandHandler<TRquest> : IRequestHandler<TRquest, CommandResult>
        where TRquest : IRequest<CommandResult>
    {
        /// <summary>
        /// Gets the required roles.
        /// </summary>
        /// <value>The required roles.</value>
        public virtual IList<string> RequiredRoles => new List<string>();

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<CommandResult> HandleAsync(TRquest message)
        {
            try
            {
                // validate
                if (message != null)
                {
                    var context = new ValidationContext(message, null, null);
                    IList<ValidationResult> validationErrors = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(message, context, validationErrors, true))
                    {
                        return new CommandResult(validationErrors);
                    }
                }

                // authorize
                bool isAuthorised = this.IsAuthorised(message.ExecutingUser);

                if (!isAuthorised)
                {
                    return new CommandResult(CommandResultReason.NotAuthorised);
                }

                await this.InvokeDomainLogicAsync(message).ConfigureAwait(false);

                return new CommandResult(CommandResultReason.Successful);
            }
            catch (Exception exception)
            {
                return new CommandResult(exception);
            }
        }
        
        /// <summary>
        /// Determines whether BO is in correct state for command.
        /// </summary>
        /// <returns>returns true if the domain object state is acceptable</returns>
        public virtual bool BoStateAcceptable()
        {
            return true;
        }

        /// <summary>
        /// Determines whether BO is visible to user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>returns true if the user can see the domain object</returns>
        public virtual bool BoVisibilityAcceptable(IPrincipal user)
        {
            return true;
        }

        /// <summary>
        /// Determines whether the specified user is authorised.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <c>true</c> if the specified user is authorised; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsAuthorised(IPrincipal user)
        {
            // return true;
            return (this.RequiredRoles.Count == 0 || this.RequiredRoles.Any(user.IsInRole))
                   && this.BoVisibilityAcceptable(user) && this.BoStateAcceptable();
        }

        /// <summary>
        /// Invokes the domain logic asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>return the task</returns>
        protected abstract Task InvokeDomainLogicAsync(TRquest request);
    }
}