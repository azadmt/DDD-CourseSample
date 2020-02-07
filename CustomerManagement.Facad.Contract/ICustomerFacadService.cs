using Common;
using CustomerManagement.Application.Contract;
using Framework.Core;
using Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Facad.Contract
{
    public interface ICustomerFacadService : IFacadeService
    {
        [Authorize(Operations.CreateAccount)]
        Guid RegisterCustomer(RegisterCustomerCommand registerCustomerCommand);
    }
}
