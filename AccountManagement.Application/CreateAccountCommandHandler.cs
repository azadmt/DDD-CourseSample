using AccountManagement.Application.Contract;
using AccountManagement.Domain.Account;
using Framework.Application;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class CreateAccountCommandHandler : CommandHandler, ICommandHandler<CreateAccountCommand>
    {
        IAccountAggregateRepository _accountAggregateRepository;
        IAccountOwnerService _accountOwnerService;
        public CreateAccountCommandHandler(IUnitOfWork uow, IAccountAggregateRepository accountAggregateRepository, IAccountOwnerService accountOwnerService)
            :base(uow)
        {
            _accountAggregateRepository = accountAggregateRepository;
            _accountOwnerService = accountOwnerService;
        }

        public void Handle(CreateAccountCommand command)
        {
            var accountOwner = _accountOwnerService.GetAccountOwner(command.OwnerId);
            var account = new AccountAggregate(accountOwner);
            _accountAggregateRepository.Save(account);
        }
    }
}
