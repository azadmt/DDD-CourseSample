using Common;
using CustomerManagement.Application.Contract;
using CustomerManagement.Customer;
using CustomerManagement.Domain.Contract;
using Framework.Application;
using Framework.Core;
using Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application
{
    public class CustomerCommandHandlers : CommandHandler, ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerAggregateRepository customerRepository;
        private readonly IEventBus bus;
        public CustomerCommandHandlers(IUnitOfWork uow, ICustomerAggregateRepository customerRepository, IEventBus bus) : base(uow)
        {
            this.customerRepository = customerRepository;
            this.bus = bus;
        }

      //  [Authorize(Operations.RegisterCustomer)] => move to Facad service
        public void Handle(RegisterCustomerCommand command)
        {
            var homeAddress = new Address(command.HomeAddress_PostalCode, command.HomeAddress_City, command.HomeAddress_Province);
            var workAddress = new Address(command.WorkAddress_PostalCode, command.WorkAddress_City, command.WorkAddress_Province);
            var aggregate = new CustomerAggregate(command.FirstName, command.LastName,command.NationalCode, homeAddress, workAddress, bus);
            customerRepository.Create(aggregate);
         //  aggregate.EventBus.Publish(new CustomerCreatedEvent(aggregate.Id));
        }

        public void Handle(RemoveCustomerCommand command)
        {        
            customerRepository.Remove(command.Id);
        }
    }
}
