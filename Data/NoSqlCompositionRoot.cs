namespace Data
{
    using Contracts;

    using LightInject;

    public class NoSqlCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IStartup, NoSqlStartup>();
            serviceRegistry.Register<IDatamapper, NoSqlDatamapper>();
            serviceRegistry.Register<IDatastore, NoSqlDataStore>();
        }
    }
}