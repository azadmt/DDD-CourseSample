using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Contract
{
    public class AccountCreatedEvent : IEvent
    {
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public decimal Balance { get; private set; }
        public string Number { get; private set; }

        public AccountCreatedEvent(Guid id, Guid ownerId, decimal balance, string number)
        {
            Id = id;
            OwnerId = ownerId;
            Balance = balance;
            Number = number;
        }
    }
}
