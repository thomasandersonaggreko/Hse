namespace Business.Commands
{
    using System.Security.Principal;

    /// <summary>
    /// The command.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Executes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The command result</returns>
        public abstract CommandResult Execute(IPrincipal user);

        /// <summary>
        /// Determines whether the specified user is authorised.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <c>true</c> if the specified user is authorised; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsAuthorised(IPrincipal user)
        {
            return true;
        }
    }
}