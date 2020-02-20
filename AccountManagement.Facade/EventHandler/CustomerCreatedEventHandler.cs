using AccountManagement.Facade.Contract.DTO;
using CustomerManagement.Domain.Contract;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Facade.Contract.EventHandler
{
    public class CustomerCreatedEventHandler : IEventHandler<CustomerCreatedEvent>
    {
        private IAccountService accountService;
        public CustomerCreatedEventHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public void Handle(CustomerCreatedEvent eventToHandle)
        {
            accountService.CreateAccount(new CreateAccountDto() { OwnerId = eventToHandle.CustomerId });
        }
    }
}
