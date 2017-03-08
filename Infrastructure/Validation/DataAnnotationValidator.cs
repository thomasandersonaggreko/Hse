namespace Infrastructure.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DataAnnotationValidator : IValidator
    {
        public IList<ValidationResult> Validate(object @object)
        {
            var context = new ValidationContext(@object, null, null);
            IList<ValidationResult> validationErrors = new List<ValidationResult>();
            Validator.TryValidateObject(@object, context, validationErrors, true);
            return validationErrors;
        }
    }
}