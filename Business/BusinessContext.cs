namespace Business
{
    using System;

    using Contracts;

    using Data;

    /// <summary>
        /// The business context.
        /// </summary>
        internal static class BusinessContext
        {
        /// <summary>
        /// The factory
        /// </summary>
        private static IBusinessContextFactory factory;

        /// <summary>
        /// Gets the datamapper.
        /// </summary>
        /// <value>
        /// The datamapper.
        /// </value>
        public static IDatamapper Datamapper => factory.Datamapper;

            /// <summary>
        /// Gets the notifier.
        /// </summary>
        /// <value>
        /// The notifier.
        /// </value>
        public static INotifier Notifier => factory.Notifier;

            /// <summary>
            /// Gets the reference number generator.
            /// </summary>
            /// <value>
            /// The reference number generator.
            /// </value>
            public static IReferenceNumberGenerator ReferenceNumberGenerator => factory.ReferenceNumberGenerator;

            /// <summary>
            /// Setups the specified business context factory.
            /// </summary>
            /// <param name="businessContextFactory">The business context factory.</param>
            public static void Setup(IBusinessContextFactory businessContextFactory)
            {
                factory = businessContextFactory;
            }
        }
}