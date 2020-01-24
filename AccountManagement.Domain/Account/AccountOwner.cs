using Framework.Domain;
using System;
using System.Collections.Generic;

namespace AccountManagement.Domain.Account
{
    public class AccountOwner : ValueObject<AccountOwner>
    {
        public Guid Id { get; private set; }
        public string NationalCode { get; private set; }

        public AccountOwner(Guid id, string nationalCode)
        {
            Id = id;
            NationalCode = nationalCode;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { Id, NationalCode };
        }
    }
}
