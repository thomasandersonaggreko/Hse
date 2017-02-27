using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface INotifier
    {
        void Notify<T>(BusinessEvent<T> businessEvent) where T : DomainObject;
    }
}
