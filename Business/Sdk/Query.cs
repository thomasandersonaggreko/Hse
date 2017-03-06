namespace Business.Sdk
{
    using System.Security.Principal;

    using Business.Queries;

    using MessageBus;

    /// <summary>
    /// The command request.
    /// </summary>
    /// <typeparam name="TProjection">The projection type
    /// </typeparam>
    public class Query<TProjection> : IRequest<QueryResult<TProjection>> where TProjection : class
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