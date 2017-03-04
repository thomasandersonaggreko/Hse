namespace Business.Commands
{
    using LightInject;

    /// <summary>
    /// The command factory.
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        /// <summary>
        /// The container
        /// </summary>
        private IServiceContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandFactory"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public CommandFactory(IServiceContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <typeparam name="T">The command type</typeparam>
        /// <returns>The command</returns>
        public T GetCommand<T>() where T : Command
        {
            return this.container.GetInstance<T>();

            // return (T)createCommand();
        }
    }
}