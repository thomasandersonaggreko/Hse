namespace Contracts
{
    using System.Linq;


    public interface IStartup
    {
        void Start();
    }
    public interface IDatastore
    {
        void Save<T>(T domainObject) where T : DomainObject;
        IQueryable<T> Query<T>() where T : class;
    }

    public interface IDatamapper
    {
        void Save<T>(T domainObject) where T : DomainObject;

        IQueryable<T> Query<T>(IDatastoreQuery query) where T : class;
    }

    public interface IDatastoreQuery
    {
        IQueryable<T> RunQuery<T>(IDatastore datastore) where T : class;
    }
}