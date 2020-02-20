using Banking.ReadModel.QueryService.Contract.DataContract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ReadModel.QueryService
{
    public class ReadModelContext : DbContext
    {
        public ReadModelContext():base("BankingQuery_DBConnection")
        {

        }

        public DbSet<AccountDto> Accounts { get; set; }
        public DbSet<CustomerDto> Customers { get; set; }
    }
}
