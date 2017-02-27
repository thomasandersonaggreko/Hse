using System;
using System.Text;
using System.Threading.Tasks;

namespace Business.Queries
{
    using System.Security.Principal;

    public abstract class Query
    {
        public virtual bool IsAuthorised(IPrincipal user)
        {
            return true;
        }

        
    }
}
