using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    using Contracts;

    using HSEModel.Projections;

    using MongoDB.Driver;

    public class NoSqlDataStore : IDatastore
    {
        IMongoDatabase database = new MongoClient().GetDatabase("HSE");

        public void Save<T>(T domainObject)
        {
            this.database.GetCollection<T>("Report").InsertOne(domainObject);
        }
        public IQueryable<T> Query<T>()
        {
           return this.database.GetCollection<T>("Report").AsQueryable();
        }

        //private ICollection<T> GetCollection<T>()
        //{
        //    if(typeof(T) == typeof(ReportListItemProjection))
        //        return this.database.GetCollection<T>("Report");
        //}
    }
}
