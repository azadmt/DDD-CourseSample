using Framework.Domain;
using System.Collections.Generic;

namespace AccountManagement.Domain.Account
{
    public class AccountNumber : ValueObject<AccountNumber>
    {
        public virtual string Number { get; protected set; }

        public AccountNumber(string ownerNationalCode)
        {
            Number = ownerNationalCode ;
        }
        protected AccountNumber() { }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { Number };
        }
    }
}
