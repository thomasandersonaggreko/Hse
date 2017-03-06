namespace Business.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The command result.
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="commandResultReason">The command result reason.</param>
        public CommandResult(CommandResultReason commandResultReason)
        {
            this.CommandResultReason = commandResultReason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public CommandResult(Exception exception)
        {
            this.CommandResultReason = CommandResultReason.UnexpectedError;
            this.Exception = exception;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResult"/> class.
        /// </summary>
        /// <param name="validationErrors">The validation errors.</param>
        public CommandResult(IList<ValidationResult> validationErrors)
        {
            this.CommandResultReason = CommandResultReason.ValidationErrors;
            this.ValidationErrors = new ReadOnlyCollection<ValidationResult>(validationErrors);
        }

        /// <summary>
        /// Gets the command result reason.
        /// </summary>
        /// <value>
        /// The command result reason.
        /// </value>
        public CommandResultReason CommandResultReason { get; private set; }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        public IReadOnlyList<ValidationResult> ValidationErrors { get; private set; }
    }
}