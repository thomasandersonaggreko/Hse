namespace Infrastructure.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The composite validation result.
    /// </summary>
    public class CompositeValidationResult : ValidationResult
    {
        /// <summary>
        /// The results
        /// </summary>
        private readonly List<ValidationResult> results = new List<ValidationResult>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeValidationResult" /> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public CompositeValidationResult(string errorMessage)
            : base(errorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeValidationResult"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="memberNames">The list of member names that have validation errors.</param>
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames)
            : base(errorMessage, memberNames)
        {
        }

        /// <summary>
        /// Gets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return this.results;
            }
        }
       
        /// <summary>
        /// Adds the result.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        public void AddResult(ValidationResult validationResult)
        {
            this.results.Add(validationResult);
        }
    }
}