namespace Business
{
    using Contracts;

    using Data;

    using LightInject;

    /// <summary>
    /// The BusinessContextFactory interface.
    /// </summary>
    internal interface IBusinessContextFactory
    {
        /// <summary>
        /// Gets the datamapper.
        /// </summary>
        /// <value>
        /// The datamapper.
        /// </value>
        IDatamapper Datamapper { get; }

        /// <summary>
        /// Gets the notifier.
        /// </summary>
        /// <value>
        /// The notifier.
        /// </value>
        INotifier Notifier { get; }

        /// <summary>
        /// Gets the reference number generator.
        /// </summary>
        /// <value>
        /// The reference number generator.
        /// </value>
        IReferenceNumberGenerator ReferenceNumberGenerator { get; }
    }

    /// <summary>
    /// The business context factory.
    /// </summary>
    internal class BusinessContextFactory : IBusinessContextFactory
    {
        /// <summary>
        /// The container
        /// </summary>
        private readonly IServiceContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessContextFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public BusinessContextFactory(IServiceContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Gets the datamapper.
        /// </summary>
        /// <value>
        /// The datamapper.
        /// </value>
        public IDatamapper Datamapper => this.container.GetInstance<IDatamapper>();

        /// <summary>
        /// Gets the notifier.
        /// </summary>
        /// <value>
        /// The notifier.
        /// </value>
        public INotifier Notifier => this.container.GetInstance<INotifier>();

        /// <summary>
        /// Gets the reference number generator.
        /// </summary>
        /// <value>
        /// The reference number generator.
        /// </value>
        public IReferenceNumberGenerator ReferenceNumberGenerator
            => this.container.GetInstance<IReferenceNumberGenerator>();
    }
}