namespace Business.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;

    using HSEModel.Commands;

    public class CommandResult
    {
        public CommandResult(CommandResultReason commandResultReason)
        {
            this.CommandResultReason = commandResultReason;
        }

        public CommandResult(Exception exception)
        {
            this.CommandResultReason = CommandResultReason.UnexpectedError;
            this.Exception = exception;
        }

        public CommandResult(IList<ValidationResult> validationErrors)
        {
            this.CommandResultReason = CommandResultReason.ValidationErrors;
            this.ValidationErrors = new ReadOnlyCollection<ValidationResult>(validationErrors);
        }

        public CommandResultReason CommandResultReason { get; private set; }

        public Exception Exception { get; private set; }

        public IReadOnlyList<ValidationResult> ValidationErrors { get; private set; }
    }
}