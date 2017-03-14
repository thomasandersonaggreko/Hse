namespace Business.Sdk
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;
    using System.Threading.Tasks;

    using Business.Queries;

    using Contracts;

    using Data;

    using Infrastructure.MessageBus;

    /// <summary>
    /// The query handler.
    /// </summary>
    /// <typeparam name="TRquest">The request type
    /// </typeparam>
    /// <typeparam name="TProjection">The projection result
    /// </typeparam>
    public abstract class QueryHandler<TRquest, TProjection> : IRequestHandler<TRquest, QueryResult<TProjection>>, IDatastoreQuery<TProjection, TRquest>
        where TRquest : IRequest<QueryResult<TProjection>> where TProjection : class
    {
        /// <summary>
        /// Gets the required roles.
        /// </summary>
        /// <value>The required roles.</value>
        public virtual IList<string> RequiredRoles => new List<string>();

        /// <summary>
        /// Gets or sets the query parameters.
        /// </summary>
        /// <value>
        /// The query parameters.
        /// </value>
        protected TRquest QueryParams { get; set; }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="message">The request message</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<QueryResult<TProjection>> HandleAsync(TRquest message)
        {
            bool isAuthorised = this.IsAuthorised(message.ExecutingUser);

            if (!isAuthorised)
            {
                return new QueryResult<TProjection>(QueryResultReason.NotAuthorised);
            }

            IQueryable<TProjection> result = BusinessContext.Datamapper.Query(this, message);

            return new QueryResult<TProjection>(await result.ToListAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Determines whether the specified user is authorised.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// <c>true</c> if the specified user is authorised; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsAuthorised(IPrincipal user)
        {
            return this.RequiredRoles.Count == 0 || this.RequiredRoles.Any(user.IsInRole);
        }

        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <param name="datamapper">The datastore.</param>
        /// <param name="queryParms">The query.</param>
        /// <returns>
        /// returns the queryable list of domain objects
        /// </returns>
        public abstract IQueryable<TProjection> RunQuery(IDatamapper datamapper, TRquest queryParms);
    }
}