using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        IEventBus EventBus { get;  }

    }
}
