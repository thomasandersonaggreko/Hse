namespace Infrastructure.DateTime
{
    using System;

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