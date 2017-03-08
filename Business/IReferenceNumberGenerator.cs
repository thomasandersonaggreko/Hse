namespace Business
{
    /// <summary>
    /// The ReferenceNumberGenerator interface.
    /// </summary>
    public interface IReferenceNumberGenerator
    {
        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns>the generated reference number</returns>
        string Generate();
    }

    /// <summary>
    /// The reference number generator.
    /// </summary>
    public class ReferenceNumberGenerator : IReferenceNumberGenerator
    {
        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns>The generated reference number</returns>
        public string Generate()
        {
            return "Test";
        }
    }
}