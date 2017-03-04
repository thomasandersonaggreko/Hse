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
        /// Saves the specified domain object.
        /// </summary>
        /// <typeparam name="T">The domain object</typeparam>
        /// <param name="domainObject">The domain object.</param>
        public void Save<T>(T domainObject) where T : DomainObject
        {
            this.database.GetCollection<T>("Report").InsertOne(domainObject);
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
