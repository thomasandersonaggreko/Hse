using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    using Contracts;

    using HSEModel.Projections;

    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class NoSqlStartup : IStartup
    {
        public void Start()
        {
            BsonClassMap.RegisterClassMap<ReportListItemProjection>(
                cm =>
                    {
                        cm.MapMember(c => c.Id);
                        cm.MapMember(c => c.ReportedByName);
                        cm.MapMember(c => c.IncidentType);
                        cm.MapMember(c => c.ReferenceNumber);
                        cm.MapMember(c => c.CreatedBy);
                        cm.MapMember(c => c.Created);
                        cm.MapMember(c => c.LastUpdated);
                        cm.MapMember(c => c.LastUpdatedBy);
                    });
        }
    }

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
