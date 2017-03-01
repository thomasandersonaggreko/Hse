namespace Data
{
    using System.Linq;

    using Contracts;

    using MongoDB.Bson.Serialization.IdGenerators;

    public class NoSqlDatamapper : IDatamapper
    {
        private IDatastore datastore;

        public NoSqlDatamapper(IDatastore datastore)
        {
            this.datastore = datastore;
        }

        public void Save<T>(T domainObject) where T : DomainObject
        {
            domainObject.Id = StringObjectIdGenerator.Instance.GenerateId(null, domainObject).ToString();
            this.datastore.Save(domainObject);
        }

        public IQueryable<T> Query<T>(IDatastoreQuery query)
        {
            return query.RunQuery<T>(this.datastore);
        }
    }
}