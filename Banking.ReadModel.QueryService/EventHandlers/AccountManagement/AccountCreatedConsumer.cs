using AccountManagement.Domain.Contract;
using Banking.ReadModel.QueryService.Contract.DataContract;
using Framework.Core;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ReadModel.QueryService.EventHandlers.AccountManagement
{
    public class AccountCreatedConsumer : IConsumer<AccountCreatedEvent>
    {
        public async Task Consume(ConsumeContext<AccountCreatedEvent> context)
        {
            using (ReadModelContext db= new ReadModelContext())
            {
                var accountOwner = db.Customers.Find(context.Message.OwnerId);
                db.Accounts.Add(new AccountDto()
                {
                    Id = context.Message.Id,
                    OwnerId = context.Message.OwnerId,
                    OwnerName = accountOwner.FirstName + " " + accountOwner.LastName,
                    Number = context.Message.Number,
                    Balance = context.Message.Balance
                });

               await db.SaveChangesAsync();
            }
        }
    }
}
