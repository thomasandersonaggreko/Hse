namespace Infrastructure
{
    using System.Collections.Generic;

    using Contracts;

    using LightInject;

    /// <summary>
    /// The service container extension.
    /// </summary>
    public static class ServiceContainerX
    {
        /// <summary>
        /// Setups the business context.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void SetupInfrastructureContext(this IServiceContainer container)
        {
            container.RegisterFrom<InfrastructureCompositionRoot>();
            container.RegisterInstance(typeof(IServiceContainer), container);
            InfrastructureContext.Setup(container.GetInstance<IInfrastructureContextFactory>());
        }

        /// <summary>
        /// Runs the startup.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void RunStartup(this IServiceContainer container)
        {
            IEnumerable<IStartup> startups = container.GetAllInstances<IStartup>();

            foreach (IStartup startup in startups)
            {
                startup.Start();
            }
        }
    }
}