namespace Data.Sql
{
    using System.Linq;

    using Contracts;

    public class SqlDataStore : IDatastore
    {
        private HseContext database = new HseContext();

        public void Save<T>(T domainObject) where T : DomainObject
        {
            this.database.Set<T>().Add(domainObject);
        }
        public IQueryable<T> Query<T>() where T : class
        {
            return this.database.Set<T>().AsQueryable();
        }
    }
}