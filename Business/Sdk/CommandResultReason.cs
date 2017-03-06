namespace Business.Sdk
{
    /// <summary>
    /// The command result reason.
    /// </summary>
    public enum CommandResultReason
    {
        /// <summary>
        /// The successful
        /// </summary>
        Successful,

        /// <summary>
        /// The not authorised
        /// </summary>
        NotAuthorised,

        /// <summary>
        /// The validation errors
        /// </summary>
        ValidationErrors,

        /// <summary>
        /// The unexpected error
        /// </summary>
        UnexpectedError
    }
}