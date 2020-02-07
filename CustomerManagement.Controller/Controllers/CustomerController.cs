using AccountManagement.Application.Contract;
using CustomerManagement.Application.Contract;
using CustomerManagement.Domain.Contract;
using CustomerManagement.Facad.Contract;
using Framework.Application;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Http;

namespace CustomerManagement.Controller.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerFacadService customerService;
        public CustomerController(ICustomerFacadService customerService)
        {
            this.customerService = customerService;
        }
        #region Move To CustomerService
        //private ICommandBus commandbus; Move to Customer Facad Service
        //private IEventBus eventBus; Move to Customer Facad Service
        //public CustomerController(ICommandBus commandbus, IEventBus eventBus)
        //{
        //    this.commandbus = commandbus;
        //    this.eventBus = eventBus;
        //}
        #endregion

        [HttpGet]
        public string Get()
        {
            return "It's worked!!!";
        }

        [HttpPost]
        public string Post(RegisterCustomerCommand command)
        {
            #region Move To CustomerService
            // Guid customerId = Guid.Empty;
            // eventBus.Subscribe(new ActionHandler<CustomerCreatedEvent>(p => id = p.Id));
            //     commandbus.Dispatch(command); 
            // 
            #endregion

            customerService.RegisterCustomer(command);
            return "OK";

        }
    }
}