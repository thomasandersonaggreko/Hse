namespace Infrastructure.Logging
{
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
    }
}