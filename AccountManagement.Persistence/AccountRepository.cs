using AccountManagement.Domain.Account;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Persistence
{
    public class AccountAggregateRepository : IAccountAggregateRepository
    {
        private ISession session;
        public AccountAggregateRepository(ISession session)
        {
            this.session = session;
        }
        public AccountAggregate Get(Guid id)
        {
            return session.Get<AccountAggregate>(id);
        }

        public void Save(AccountAggregate accountAggregate)
        {
            session.Save(accountAggregate);
        }
    }
}
