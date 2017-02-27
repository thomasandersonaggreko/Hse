namespace Contracts
{
    public class BusinessEvent<TObject> where TObject : DomainObject
    {

        public TObject DomainObject { get; set; }
    }
}