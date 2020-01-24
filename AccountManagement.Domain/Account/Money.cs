using Framework.Domain;
using System.Collections.Generic;

namespace AccountManagement.Domain.Account
{
    public class Money : ValueObject<Money>
    {
        public virtual decimal Amount { get; protected set; }
        public Money(decimal amount)
        {
            SetAmount(amount);
        }
        protected Money()
        {

        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { Amount };
        }

        private void SetAmount(decimal amount)
        {
            if (amount < 0)
            {
                throw new System.Exception("Amount is not supported for money!!!");
            }
            Amount = amount;
        }

        public static Money operator +(Money left, Money right)
        {
            return new Money(left.Amount + right.Amount);
        }

        public static Money operator -(Money left, Money right)
        {
            return new Money(left.Amount - right.Amount);
        }

        public static bool operator <(Money left, Money right)
        {
            return left.Amount < right.Amount;
        }

        public static bool operator >(Money left, Money right)
        {
            return left.Amount > right.Amount;
        }
    }
}
