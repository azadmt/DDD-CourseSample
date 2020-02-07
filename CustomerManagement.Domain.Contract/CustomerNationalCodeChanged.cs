using Framework.Core;
using System;

namespace CustomerManagement.Domain.Contract
{
    public class CustomerNationalCodeChanged:IEvent
    {
        public Guid CustomerId { get; private set; }
        public string  NationalCode{ get; private set; }
        public CustomerNationalCodeChanged(Guid customerId,string nationalCode)
        {
            CustomerId = customerId;
            NationalCode = nationalCode;
        }
    }
}
