using AccountManagement.Domain.Account;
using CustomerManagement.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.CustomerManagementACL
{
    public class CustomerACL : IAccountOwnerService
    {
        ICustomerAggregateRepository _customerAggregateRepository;
        public CustomerACL(ICustomerAggregateRepository customerAggregateRepository)
        {
            _customerAggregateRepository = customerAggregateRepository;
        }

        public AccountOwner GetAccountOwner(string nationalCode)
        {
            var customer = _customerAggregateRepository.FindBy(nationalCode);
            return new AccountOwner(customer.Id, customer.NationalCode.Code);
        }
    }
}
