namespace Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;

    using HSEModel.ReadModel;

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
            return this.database.GetCollection<T>(this.GetCollectionName<T>()).InsertOneAsync(domainObject);
        }

        /// <summary>
        /// Queries the specified query.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <typeparam name="TK">The type of the k.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="values">The values.</param>
        /// <returns>
        /// Queryable list of domain objects
        /// </returns>
        public IQueryable<T> Query<T, TK>(IDatastoreQuery<T, TK> query, TK values) where T : class
        {
            return query.RunQuery(this, values);
        }

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <returns>the query</returns>
        public IQueryable<T> Query<T>() where T : class
        {
            return this.database.GetCollection<T>(this.GetCollectionName<T>()).AsQueryable();
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
            return this.database.GetCollection<T>(this.GetCollectionName<T>()).ReplaceOneAsync(x => x.Id == domainObject.Id, domainObject, new UpdateOptions() { IsUpsert = true });
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
            IAsyncCursor<T> cursor = await this.database.GetCollection<T>(this.GetCollectionName<T>()).FindAsync(x => x.Id == id).ConfigureAwait(false);
            return cursor.FirstOrDefault();
        }

        /// <summary>
        /// Gets the name of the collection.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <returns>The collection name</returns>
        private string GetCollectionName<T>()
        {
            if (typeof(T) == typeof(MonthlyHighPotentialIncidents))
            {
                return typeof(MonthlyHighPotentialIncidents).Name;
            }

            return "Report";
        }
    }
}