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
    public abstract class QueryHandler<TRquest, TProjection> : IRequestHandler<TRquest, QueryResult<TProjection>>, IDatastoreQuery
        where TRquest : IRequest<QueryResult<TProjection>> where TProjection : class
    {
        /// <summary>
        /// The datamapper
        /// </summary>
        private IDatamapper datamapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryHandler{TRquest, TProjection}"/> class.
        /// </summary>
        /// <param name="datamapper">The datamapper.</param>
        protected QueryHandler(IDatamapper datamapper)
        {
            this.datamapper = datamapper;
        }

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
        public async Task<QueryResult<TProjection>> HandleAsync(TRquest message)
        {
            bool isAuthorised = this.IsAuthorised(message.ExecutingUser);

            if (!isAuthorised)
            {
                return new QueryResult<TProjection>(QueryResultReason.NotAuthorised);
            }

            IQueryable<TProjection> result = this.datamapper.Query<TProjection>(this);

            return new QueryResult<TProjection>(result.ToList());
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
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="datastore">The datastore.</param>
        /// <returns>returns the queryable list of domain objects</returns>
        public abstract IQueryable<TObject> RunQuery<TObject>(IDatastore datastore) where TObject : class;
    }
}