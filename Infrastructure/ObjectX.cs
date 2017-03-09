namespace Contracts
{
    public static class ObjectX
    {
        public static string ToJson(this object @object)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(@object);
        }
    }
}