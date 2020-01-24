using AccountManagement.Application.Contract;
using Framework.Application;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AccountManagement.Controller.Controllers
{
    public class AccountController : ApiController
    {

        private ICommandBus commandbus;
        private IEventBus eventBus;
        public AccountController(ICommandBus commandbus, IEventBus eventBus)
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
        public string Post(CreateAccountCommand command)
        {
            // eventBus.Subscribe<CustomerCreatedEvent>
            commandbus.Dispatch(command);
            return "OK";
        }
    }
}
