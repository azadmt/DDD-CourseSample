using AccountManagement.Facade.Contract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Facade.Contract
{
    public interface IAccountService
    {
        void CreateAccount(CreateAccountDto createAccountDto);
    }
}
