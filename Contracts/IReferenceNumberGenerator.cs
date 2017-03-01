namespace Contracts
{
    public interface IReferenceNumberGenerator
    {
        string Generate();
    }

    public class ReferenceNumberGenerator : IReferenceNumberGenerator
    {
        public string Generate()
        {
            return "Test";
        }
    }
}