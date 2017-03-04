namespace Business.Queries
{
    using LightInject;

    /// <summary>
    /// The query factory.
    /// </summary>
    public class QueryFactory : IQueryFactory
    {
        /// <summary>
        /// The container
        /// </summary>
        private IServiceContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public QueryFactory(IServiceContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <typeparam name="T">The query result object</typeparam>
        /// <returns>The query</returns>
        public T GetQuery<T>()
        {
            return this.container.GetInstance<T>();

            // return (T)createCommand();
        }
    }
}