using Framework.Domain;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Account
{
    public class AccountAggregate : Entity
    {
        public virtual Guid OwnerId { get; protected set; }
        public virtual AccountNumber Number { get; protected set; }
        public virtual Money Balance { get; protected set; }

        public AccountAggregate(AccountOwner accountOwner)
        {
            OwnerId = accountOwner.Id;
            SetNumber(accountOwner);
            Balance = new Money(0);
        }

        protected AccountAggregate()
        {

        }


        public virtual void Deposit(Money amount)
        {
            Balance += amount;
        }

        public virtual void Widthraw(Money amount)
        {
            if (amount > Balance)
                throw new Exception("Amount is greater than  account balance !!!!");
            Balance -= amount;
        }

        private void SetNumber(AccountOwner accountOwner)
        {
            Number = new AccountNumber(accountOwner.NationalCode);
        }
    }
}
