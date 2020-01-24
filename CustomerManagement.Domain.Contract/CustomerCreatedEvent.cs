using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Contract
{
    public class CustomerCreatedEvent : IEvent
    {
        public Guid Id { get; private set; }

        public CustomerCreatedEvent(Guid id)
        {
            Id = id;
        }
    }
}
