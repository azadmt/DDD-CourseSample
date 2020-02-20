using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Contract
{
    public class CustomerCreatedEvent : IEvent, IExternalMessage
    {
        public Guid CustomerId { get; private set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string HomeAddressPostalCode { get; private set; }
        public string HomeAddressCity { get; private set; }
        public string HomeAddressProvince { get; private set; }


        public string WorkAddressPostalCode { get; private set; }
        public string WorkAddressCity { get; private set; }
        public string WorkAddressProvince { get; private set; }

        public CustomerCreatedEvent(Guid id, string firstName, string lastName,
            string homeAddressPostalCode, string homeAddressCity, string homeAddressProvince,
           string workAddressPostalCode, string workAddressCity, string workAddressProvince)
        {
            CustomerId = id;
            FirstName = firstName;
            LastName = lastName;

            HomeAddressCity = homeAddressCity;
            HomeAddressPostalCode = homeAddressPostalCode;
            HomeAddressProvince = homeAddressProvince;

            WorkAddressCity = workAddressCity;
            WorkAddressPostalCode = workAddressPostalCode;
            WorkAddressProvince = workAddressProvince;

        }
    }
}
