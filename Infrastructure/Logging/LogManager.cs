namespace Infrastructure.Logging
{
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
    }
}