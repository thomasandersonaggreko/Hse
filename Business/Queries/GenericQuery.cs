namespace Business.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;

    using Contracts;

    /// <summary>
    /// The generic query.
    /// </summary>
    /// <typeparam name="TObject"> The domain object
    /// </typeparam>
    public abstract class GenericQuery<TObject> : Query, IDatastoreQuery
        where TObject : class
    {
        /// <summary>
        /// The datamapper
        /// </summary>
        private IDatamapper datamapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericQuery{TObject}"/> class.
        /// </summary>
        /// <param name="datamapper">The datamapper.</param>
        protected GenericQuery(IDatamapper datamapper)
        {
            this.datamapper = datamapper;
        }

        /// <summary>
        /// Gets the required roles.
        /// </summary>
        /// <value>
        /// The required roles.
        /// </value>
        public virtual IList<string> RequiredRoles => new List<string>();

        /// <summary>
        /// Executes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The query result</returns>
        public QueryResult<TObject> Execute(IPrincipal user)
        {
            bool isAuthorised = this.IsAuthorised(user);

            if (!isAuthorised)
            {
                return new QueryResult<TObject>(QueryResultReason.NotAuthorised);
            }

            IQueryable<TObject> result = this.datamapper.Query<TObject>(this);

            return new QueryResult<TObject>(result.ToList());
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