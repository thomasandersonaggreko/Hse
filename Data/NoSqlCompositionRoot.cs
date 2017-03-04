namespace Data
{
    using Contracts;

    using LightInject;

    /// <summary>
    /// The no sql composition root.
    /// </summary>
    public class NoSqlCompositionRoot : ICompositionRoot
    {
        /// <summary>
        /// Composes services by adding services to the <paramref name="serviceRegistry" />.
        /// </summary>
        /// <param name="serviceRegistry">The target <see cref="T:LightInject.IServiceRegistry" />.</param>
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IStartup, NoSqlStartup>();
            serviceRegistry.Register<IDatamapper, NoSqlDatamapper>();
            serviceRegistry.Register<IDatastore, NoSqlDataStore>();
        }
    }
}