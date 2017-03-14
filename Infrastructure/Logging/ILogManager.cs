namespace Infrastructure.Logging
{
    using System;

    /// <summary>
    /// The LogManager interface.
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ILogger GetLogger<T>();

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        ILogger GetLogger(Type type);
    }
}