namespace Infrastructure.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    using Infrastructure.Logging;

    /// <summary>
    /// The data annotation validator.
    /// </summary>
    public class DataAnnotationValidator : IValidator
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILogger Logger = InfrastructureContext.LogManager.GetLogger<DataAnnotationValidator>();

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns>The list of validation errors</returns>
        public IList<ValidationResult> Validate(object @object)
        {
            Logger.Debug(() => $"Validating - {@object.ToJson()}");

            var context = new ValidationContext(@object, null, null);
            IList<ValidationResult> validationErrors = new List<ValidationResult>();
            if (Validator.TryValidateObject(@object, context, validationErrors, true))
            {
                Logger.Debug(() => $"Validation Passed - {@object.ToJson()}");
            }
            else
            {
                Logger.Debug(() => $"Validation Failed For - {@object.ToJson()} - {validationErrors.ToJson()}");
            }

            return validationErrors;
        }
    }
}