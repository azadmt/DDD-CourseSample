using Framework.Domain;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Customer
{
    public class NationalCode : ValueObject<NationalCode>
    {
        public virtual string Code { get; protected set; }
        public NationalCode(string nationalCode)
        {
            if (nationalCode.Length != 10)
                throw new Exception("NationalCode Value is not valid !!!!");
           Code = nationalCode;
        }

        protected NationalCode()
        {

        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { Code };
        }
    }
}
