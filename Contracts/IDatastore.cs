namespace Contracts
{
    using System.Linq;

    public interface IDatastore
    {
        void Save<T>(T domainObject);
        IQueryable<T> Query<T>();
    }

    public interface IDatamapper
    {
        void Save<T>(T domainObject);

        IQueryable<T> Query<T>(IDatastoreQuery query);
    }

    public interface IDatastoreQuery
    {
        IQueryable<T> RunQuery<T>(IDatastore datastore);
    }
}