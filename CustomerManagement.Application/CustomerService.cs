using CustomerManagement.Application.Contract;
using CustomerManagement.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application
{
    //public class CustomerService : ICustomerService
    //{
    //    private ICustomerRepository _customerRepository;
    //    public CustomerService(ICustomerRepository customerRepository)
    //    {

    //    }

    //    public void CreateCustomer(CreateCustomerDto createCustomerDto)
    //    {
    //        var homeAddress = new Address(createCustomerDto.HomeAddress_PostalCode, createCustomerDto.HomeAddress_City, createCustomerDto.HomeAddress_Province);
    //        var workAddress = new Address(createCustomerDto.WorkAddress_PostalCode, createCustomerDto.WorkAddress_City, createCustomerDto.WorkAddress_Province);
    //        var aggregate = new CustomerAggregate(createCustomerDto.FirstName, createCustomerDto.LastName, homeAddress, workAddress);
    //        _customerRepository.Create(aggregate);
    //    }
    //}
}
