using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IEvent
    {
    }

    public interface IExternalMessage
    {
    }

    public interface IEventHandler<T> where T : IEvent
    {
        void Handle(T eventToHandle);
    }
}
