namespace Business.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Principal;

    using HSEModel.Commands;

    /// <summary>
    /// The generic command.
    /// </summary>
    /// <typeparam name="TObject">The domain object
    /// </typeparam>
    public abstract class GenericCommand<TObject> : Command
    {
        /// <summary>
        /// Gets or sets the domain object.
        /// </summary>
        /// <value>
        /// The domain object.
        /// </value>
        public TObject DomainObject { get; set; }

        /// <summary>
        /// Gets the required roles.
        /// </summary>
        /// <value>The required roles.</value>
        public virtual IList<string> RequiredRoles => new List<string>();

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
        /// Executes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>returns the command result</returns>
        public override CommandResult Execute(IPrincipal user)
        {
            try
            {
                // validate
                if (this.DomainObject != null)
                {
                    var context = new ValidationContext(this.DomainObject, null, null);
                    IList<ValidationResult> validationErrors = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(this.DomainObject, context, validationErrors, true))
                    {
                        return new CommandResult(validationErrors);
                    }
                }

                // authorize
                bool isAuthorised = this.IsAuthorised(user);

                if (!isAuthorised)
                {
                    return new CommandResult(CommandResultReason.NotAuthorised);
                }

                this.InvokeDomainLogic(user);

                return new CommandResult(CommandResultReason.Successful);
            }
            catch (Exception exception)
            {
                return new CommandResult(exception);
            }
        }

        /// <summary>
        /// Determines whether the specified user is authorised.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// <c>true</c> if the specified user is authorised; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsAuthorised(IPrincipal user)
        {
            // return true;
            return (this.RequiredRoles.Count == 0 || this.RequiredRoles.Any(user.IsInRole))
                   && this.BoVisibilityAcceptable(user) && this.BoStateAcceptable();
        }

        /// <summary>
        /// Invokes the domain logic.
        /// </summary>
        /// <param name="user">The user.</param>
        protected abstract void InvokeDomainLogic(IPrincipal user);
    }
}