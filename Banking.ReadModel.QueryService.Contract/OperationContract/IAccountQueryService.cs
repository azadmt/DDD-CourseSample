using Banking.ReadModel.QueryService.Contract.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ReadModel.QueryService.Contract.OperationContract
{
    public interface IAccountQueryService
    {
        List<AccountDto> GetAccounts();
    }
}
