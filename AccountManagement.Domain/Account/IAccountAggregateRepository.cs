using System;

namespace AccountManagement.Domain.Account
{
    public interface IAccountAggregateRepository
    {
        AccountAggregate Get(Guid id);

        void Save(AccountAggregate accountAggregate);
    }
}
