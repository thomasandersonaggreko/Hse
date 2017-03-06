using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    using Contracts;

    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    /// <summary>
    /// The no sql data store.
    /// </summary>
    public class NoSqlDataStore : IDatastore
    {
        /// <summary>
        /// The database
        /// </summary>
        private IMongoDatabase database = new MongoClient().GetDatabase("HSE");

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <typeparam name="T">The domain object type</typeparam>
        /// <param name="domainObject">The domain object.</param>
        /// <returns>
        /// Returns the task
        /// </returns>
        public Task SaveAsync<T>(T domainObject) where T : DomainObject
        {
            return this.database.GetCollection<T>("Report").InsertOneAsync(domainObject);
        }

        /// <summary>
        /// Queries this instance.
        /// </summary>
        /// <typeparam name="T">The Domain object</typeparam>
        /// <returns>return queryable of domain objects</returns>
        public IQueryable<T> Query<T>() where T : class
        {
            return this.database.GetCollection<T>("Report").AsQueryable();
        }
    }
}
