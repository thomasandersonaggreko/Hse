namespace Business.Queries
{
    using System.Security.Principal;

    /// <summary>
    /// The query.
    /// </summary>
    public abstract class Query
    {
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