using Framework.Core;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ServiceBus.MassTransit
{
    public class MassTransitServiceBus : IEnterpriseServiceBus
    {
        IBusControl massTransitBus;
        public MassTransitServiceBus(IBusControl busControl)
        {
            massTransitBus = busControl;
        }
        public async Task Publish<T>(T @event) where T: IExternalMessage
        {
            await massTransitBus.Publish(@event);           
        }
    }
}
