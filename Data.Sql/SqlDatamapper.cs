namespace Data.Sql
{
    using System;
    using System.Linq;

    using Contracts;

    public class SqlDatamapper : IDatamapper
    {
        private IDatastore datastore;

        public SqlDatamapper(IDatastore datastore)
        {
            this.datastore = datastore;
        }

        public void Save<T>(T domainObject) where T : DomainObject
        {
            domainObject.Id = Guid.NewGuid().ToString();
            this.datastore.Save(domainObject);
        }

        public IQueryable<T> Query<T>(IDatastoreQuery query) where T : class
        {
            return query.RunQuery<T>(this.datastore);
        }
    }
}