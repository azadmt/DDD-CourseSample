using CustomerManagement.Application.Contract;
using CustomerManagement.Domain.Contract;
using Framework.Application;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CustomerManagement.Controller.Controllers
{
    public class CustomerController : ApiController
    {
        //private ICustomerService customerService;
        //public CustomerController(ICustomerService customerService )
        //{
        //    this.customerService = customerService;
        //}

        private ICommandBus commandbus;
        private IEventBus eventBus;
        public CustomerController(ICommandBus commandbus, IEventBus eventBus)
        {
            this.commandbus = commandbus;
            this.eventBus = eventBus;
        }

        [HttpGet]
        public string Get()
        {
            return "It's worked!!!";
        }

        [HttpPost]
        public string Post(RegisterCustomerCommand command)
        {
            Guid id = Guid.Empty;
            eventBus.Subscribe(new ActionHandler<CustomerCreatedEvent>(p => id=p.Id));
            commandbus.Dispatch(command);
            return "OK";
        }
    }
}