namespace Contracts
{
    using System;

    /// <summary>
    /// The DateTimeProvider interface.
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Gets the now.
        /// </summary>
        /// <value>
        /// The now.
        /// </value>
        DateTime Now { get; }
    }

    /// <summary>
    /// The date time provider.
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Gets the now.
        /// </summary>
        /// <value>
        /// The now.
        /// </value>
        public DateTime Now => DateTime.Now;
    }
}