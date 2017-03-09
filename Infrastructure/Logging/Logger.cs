namespace Infrastructure.Logging
{
    using System;

    /// <summary>
    /// The logger.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly NLog.Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public Logger(NLog.Logger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(Func<string> message)
        {
            if (this.logger.IsDebugEnabled)
            {
                this.logger.Debug(message());
            }
        }

        /// <summary>
        /// Information the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(Func<string> message)
        {
            if (this.logger.IsInfoEnabled)
            {
                this.logger.Info(message());
            }
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warn(Func<string> message)
        {
            if (this.logger.IsWarnEnabled)
            {
                this.logger.Warn(message());
            }
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(Func<string> message, Exception exception)
        {
            if (this.logger.IsErrorEnabled)
            {
                this.logger.Error(exception, message());
            }
        }

        public void Trace(Func<string> message)
        {
            throw new NotImplementedException();
        }
    }
}