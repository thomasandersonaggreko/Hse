namespace Infrastructure.DateTime
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
}