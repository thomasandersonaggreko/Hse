namespace Business
{
    using LightInject;

    /// <summary>
    /// The service container extensions.
    /// </summary>
    public static class ServiceContainerX
    {
        /// <summary>
        /// Setups the business context.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void SetupBusinessContext(this IServiceContainer container)
        {
            BusinessContext.Setup(container.GetInstance<IBusinessContextFactory>());
            container.RegisterFrom<BusinessCompositionRoot>();
        }
    }
}