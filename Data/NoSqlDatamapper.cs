namespace Data
{
    using System.Linq;

    using Contracts;

    public class NoSqlDatamapper : IDatamapper
    {
        private IDatastore datastore;

        public NoSqlDatamapper(IDatastore datastore)
        {
            this.datastore = datastore;
        }

        public void Save<T>(T domainObject)
        {
            this.datastore.Save(domainObject);
        }

        public IQueryable<T> Query<T>(IDatastoreQuery query)
        {
            return query.RunQuery<T>(this.datastore);
        }
    }
}