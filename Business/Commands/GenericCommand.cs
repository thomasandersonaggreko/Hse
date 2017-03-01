namespace Business.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Principal;

    using HSEModel.Commands;

    public abstract class GenericCommand<TObject> : Command
    {
       
        public TObject DomainObject { get; set; }

        #region Authorisation
        

        /// <summary>
        /// Determines whether the specified user is authorised.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// 	<c>true</c> if the specified user is authorised; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsAuthorised(IPrincipal user)
        {
           // return true;
            return (this.RequiredRoles.Count == 0 || this.RequiredRoles.Any(user.IsInRole)) &&
                   this.BoVisibilityAcceptable(user) &&
                   this.BoStateAcceptable();
        }

        /// <summary>
        /// Gets the required roles.
        /// </summary>
        /// <value>The required roles.</value>
        public virtual IList<string> RequiredRoles => new List<string>();

        /// <summary>
        /// Determines whether BO is visible to user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public virtual bool BoVisibilityAcceptable(IPrincipal user)
        {
            return true;
        }

        /// <summary>
        /// Determines whether BO is in correct state for command.
        /// </summary>
        /// <returns></returns>
        public virtual bool BoStateAcceptable()
        {
            return true;
        }

        #endregion

        public override CommandResult Execute(IPrincipal user)
        {
            try
            {
                //validate
                if (this.DomainObject != null)
                {
                    var context = new ValidationContext(this.DomainObject, null, null);
                    IList<ValidationResult> validationErrors = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(this.DomainObject, context, validationErrors, true))
                    {
                        return new CommandResult(validationErrors);
                    }
                }

                //authorize
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

        protected abstract void InvokeDomainLogic(IPrincipal user);
    }
}
