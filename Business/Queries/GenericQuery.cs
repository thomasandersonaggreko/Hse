namespace Business.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Principal;

    using Contracts;

    using HSEModel.Projections;

    public abstract class GenericQuery<TObject> : Query, IDatastoreQuery
    {
        private IDatamapper datamapper;

        protected GenericQuery(IDatamapper datamapper)
        {
            this.datamapper = datamapper;
        }

        #region Authorisation

        /// <summary>
        /// Determines whether the specified user is authorised.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// 	<c>true</c> if the specified user is authorised; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsAuthorised(IPrincipal user)
        {
            return (this.RequiredRoles.Count == 0 || this.RequiredRoles.Any(user.IsInRole));

        }

        /// <summary>
        /// Gets the required roles.
        /// </summary>
        /// <value>The required roles.</value>
        public virtual IList<string> RequiredRoles => new List<string>();


        #endregion

        public QueryResult<TObject> Execute(IPrincipal user)
        {
            bool isAuthorised = this.IsAuthorised(user);

            if (!isAuthorised)
            {
                return new QueryResult<TObject>();
            }

            IQueryable<TObject> result = this.datamapper.Query<TObject>(this);

            return new QueryResult<TObject>(result.ToList());
        }

        public abstract IQueryable<TObject> RunQuery<TObject>(IDatastore datastore);
    }
}