using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IEnterpriseServiceBus
    {
        Task Publish<T>(T @event) where T : IExternalMessage;
    }
}
