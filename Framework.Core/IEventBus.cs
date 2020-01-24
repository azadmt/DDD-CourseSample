using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IEventBus
    {
        void Subscribe<T>(IEventHandler<T> handler) where T : IEvent;
        void Publish<T>(T eventToPublish) where T : IEvent;
    }
}
