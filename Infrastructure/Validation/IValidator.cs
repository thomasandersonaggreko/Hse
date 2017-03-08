namespace Infrastructure.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public interface IValidator
    {
        IList<ValidationResult> Validate(object @object);
    }
}