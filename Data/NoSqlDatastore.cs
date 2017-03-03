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

    public class NoSqlDataStore : IDatastore
    {
        IMongoDatabase database = new MongoClient().GetDatabase("HSE");

        public void Save<T>(T domainObject) where T : DomainObject
        {
            this.database.GetCollection<T>("Report").InsertOne(domainObject);
        }
        public IQueryable<T> Query<T>() where T : class
        {
            return this.database.GetCollection<T>("Report").AsQueryable();
        }
    }
}
