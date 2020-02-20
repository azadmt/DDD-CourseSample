using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ReadModel.QueryService.Contract.DataContract
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Number { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }
    }

    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string HomeAddressPostalCode { get;  set; }
        public string HomeAddressCity { get;  set; }
        public string HomeAddressProvince { get;  set; }


        public string WorkAddressPostalCode { get;  set; }
        public string WorkAddressCity { get;  set; }
        public string WorkAddressProvince { get;  set; }

    }
}
