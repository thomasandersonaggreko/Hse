namespace Infrastructure.Logging
{
    using System;

    /// <summary>
    /// Provides logging interface and utility functions.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(Func<string> message);

        /// <summary>
        /// Information the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(Func<string> message);

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(Func<string> message);

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Error(Func<string> message, Exception exception);

        /// <summary>
        /// Traces the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Trace(Func<string> message);
    }
}
