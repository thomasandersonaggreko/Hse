namespace Infrastructure
{
    using Infrastructure.DateTime;
    using Infrastructure.Logging;
    using Infrastructure.MessageBus;
    using Infrastructure.Validation;

    using LightInject;

    /// <summary>
    /// The InfrastructureContextFactory interface.
    /// </summary>
    public interface IInfrastructureContextFactory
    {
        /// <summary>
        /// Gets the datamapper.
        /// </summary>
        /// <value>
        /// The datamapper.
        /// </value>
        IValidator Validator { get; }

        /// <summary>
        /// Gets the notifier.
        /// </summary>
        /// <value>
        /// The notifier.
        /// </value>
        IBus Bus { get; }

        /// <summary>
        /// Gets the reference number generator.
        /// </summary>
        /// <value>
        /// The reference number generator.
        /// </value>
        IDateTimeProvider DateTimeProvider { get; }

        /// <summary>
        /// Gets the log manager.
        /// </summary>
        /// <value>
        /// The log manager.
        /// </value>
        ILogManager LogManager { get; }
    }

    /// <summary>
    /// The infrastructure context factory.
    /// </summary>
    public class InfrastructureContextFactory : IInfrastructureContextFactory
    {
        /// <summary>
        /// The container
        /// </summary>
        private readonly IServiceContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="InfrastructureContextFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public InfrastructureContextFactory(IServiceContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Gets the datamapper.
        /// </summary>
        /// <value>
        /// The datamapper.
        /// </value>
        public IValidator Validator => this.container.GetInstance<IValidator>();

        /// <summary>
        /// Gets the notifier.
        /// </summary>
        /// <value>
        /// The notifier.
        /// </value>
        public IBus Bus => this.container.GetInstance<IBus>();

        /// <summary>
        /// Gets the reference number generator.
        /// </summary>
        /// <value>
        /// The reference number generator.
        /// </value>
        public IDateTimeProvider DateTimeProvider
            => this.container.GetInstance<IDateTimeProvider>();

        /// <summary>
        /// Gets the log manager.
        /// </summary>
        /// <value>
        /// The log manager.
        /// </value>
        public ILogManager LogManager => this.container.GetInstance<ILogManager>();
    }
}