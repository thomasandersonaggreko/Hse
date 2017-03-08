using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    using Infrastructure.DateTime;
    using Infrastructure.MessageBus;
    using Infrastructure.Validation;

    /// <summary>
    /// The infrastructure context.
    /// </summary>
    public static class InfrastructureContext
    {
        /// <summary>
        /// The factory
        /// </summary>
        private static IInfrastructureContextFactory factory;

        /// <summary>
        /// Gets the date time provider.
        /// </summary>
        /// <value>
        /// The date time provider.
        /// </value>
        public static IDateTimeProvider DateTimeProvider => factory.DateTimeProvider;

        /// <summary>
        /// Gets the bus.
        /// </summary>
        /// <value>
        /// The bus.
        /// </value>
        public static IBus Bus => factory.Bus;

        /// <summary>
        /// Gets the validator.
        /// </summary>
        /// <value>
        /// The validator.
        /// </value>
        public static IValidator Validator => factory.Validator;

        /// <summary>
        /// Setups the specified business context factory.
        /// </summary>
        /// <param name="infrastructureContextFactory">The business context factory.</param>
        public static void Setup(IInfrastructureContextFactory infrastructureContextFactory)
        {
            factory = infrastructureContextFactory;
        }
    }
}
