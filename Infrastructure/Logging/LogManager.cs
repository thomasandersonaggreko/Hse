namespace Infrastructure.Logging
{
    using System;

    /// <summary>
    /// The log manager.
    /// </summary>
    public class LogManager : ILogManager
    {
        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <typeparam name="T">The type which is being logged</typeparam>
        /// <returns>The Logger</returns>
        public ILogger GetLogger<T>()
        {
            NLog.Logger logger = NLog.LogManager.GetLogger(typeof(T).Name);
            return new Logger(logger);
        }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The logger</returns>
        public ILogger GetLogger(Type type)
        {
            NLog.Logger logger = NLog.LogManager.GetLogger(type.Name);
            return new Logger(logger);
        }
    }
}