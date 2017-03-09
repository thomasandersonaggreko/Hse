namespace Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;

    using MongoDB.Bson.Serialization.IdGenerators;
    using MongoDB.Driver;

    /// <summary>
    /// The no sql datamapper.
    /// </summary>
    public class NoSqlDatamapper : IDatamapper
    {
        /// <summary>
        /// The database
        /// </summary>
        private readonly IMongoDatabase database = new MongoClient().GetDatabase("HSE");

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns>
        /// Return the async task
        /// </returns>
        public Task SaveAsync<T>(T domainObject) where T : DomainObject
        {
            domainObject.Id = StringObjectIdGenerator.Instance.GenerateId(null, domainObject).ToString();
            return this.database.GetCollection<T>("Report").InsertOneAsync(domainObject);
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
            return query.RunQuery<T>(this);
        }

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <returns>the query</returns>
        public IQueryable<T> Query<T>() where T : class
        {
            return this.database.GetCollection<T>("Report").AsQueryable();
        }

        /// <summary>
        /// Updates the specified domain object.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns>
        /// Return the async task
        /// </returns>
        public Task UpdateAsync<T>(T domainObject) where T : DomainObject
        {
            return this.database.GetCollection<T>("Report").ReplaceOneAsync(x => x.Id == domainObject.Id, domainObject);
        }

        /// <summary>
        /// Loads the specified identifier.
        /// </summary>
        /// <typeparam name="T">the domain object</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// returns the domain object
        /// </returns>
        public async Task<T> Load<T>(string id) where T : DomainObject
        {
            IAsyncCursor<T> cursor = await this.database.GetCollection<T>("Report").FindAsync(x => x.Id == id).ConfigureAwait(false);
            return cursor.FirstOrDefault();
        }
    }
}