using AccountManagement.Domain.Account;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Persistence.Mapping
{
    public class AccountAggregateMapping : ClassMapping<AccountAggregate>
    {
        public AccountAggregateMapping()
        {
            Table("Accounts");
            Id(p => p.Id, p => p.Access(Accessor.Field));

            Property(p => p.OwnerId, p => p.Access(NHibernate.Mapping.ByCode.Accessor.Property));

            Component(p => p.Balance, z =>
            {
                z.Property(a => a.Amount, a =>
                {
                    a.Column("Balance");                  
                }
                );
            });

            Component(p => p.Number, z =>
            {
                z.Property(a => a.Number, a =>
                {
                    a.Column("Number");
                }
                );
            });

        }
    }
}
