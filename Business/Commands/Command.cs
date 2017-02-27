namespace Business.Commands
{
    using System.Security.Principal;

    public abstract class Command
    {
        public virtual bool IsAuthorised(IPrincipal user)
        {
            return true;
        }
    }
}