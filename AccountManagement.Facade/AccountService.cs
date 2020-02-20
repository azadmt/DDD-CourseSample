using AccountManagement.Application.Contract;
using AccountManagement.Facade.Contract;
using AccountManagement.Facade.Contract.DTO;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Facade
{
    public class AccountService : IAccountService
    {
        private readonly ICommandBus commandBus;
        public AccountService(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
        public void CreateAccount(CreateAccountDto createAccountDto)
        {
            commandBus.Dispatch(new CreateAccountCommand() { OwnerId = createAccountDto.OwnerId });
        }
    }
}
