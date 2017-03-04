namespace Data
{
    using System.Linq;

    using Contracts;

    using MongoDB.Bson.Serialization.IdGenerators;

    /// <summary>
    /// The no sql datamapper.
    /// </summary>
    public class NoSqlDatamapper : IDatamapper
    {
        /// <summary>
        /// The datastore
        /// </summary>
        private IDatastore datastore;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoSqlDatamapper"/> class.
        /// </summary>
        /// <param name="datastore">The datastore.</param>
        public NoSqlDatamapper(IDatastore datastore)
        {
            this.datastore = datastore;
        }

        /// <summary>
        /// Saves the specified domain object.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="domainObject">The domain object.</param>
        public void Save<T>(T domainObject) where T : DomainObject
        {
            domainObject.Id = StringObjectIdGenerator.Instance.GenerateId(null, domainObject).ToString();
            this.datastore.Save(domainObject);
        }

        /// <summary>
        /// Queries the specified query.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>
        /// Queryable list of domain objects
        /// </returns>
        public IQueryable<T> Query<T>(IDatastoreQuery query) where T : class
        {
            return query.RunQuery<T>(this.datastore);
        }
    }
}