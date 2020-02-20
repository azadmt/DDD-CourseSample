using Banking.ReadModel.QueryService.Contract.DataContract;
using Banking.ReadModel.QueryService.Contract.OperationContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ReadModel.QueryService
{
    public class AccountQueryService : IAccountQueryService
    {
        public List<AccountDto> GetAccounts()
        {
            using (var context = new ReadModelContext())
            {
                return context.Accounts.ToList();
            }
        }
    }
}
