using CustomerManagement.Customer;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Persistence
{
    public class CustomerMapping : ClassMapping<CustomerAggregate>
    {
        public CustomerMapping()
        {
            Table("Customers");
            Id(p => p.Id);
            Property(p => p.FirstName, p => p.Access(NHibernate.Mapping.ByCode.Accessor.Property));
            Property(p => p.LastName, p => p.Access(NHibernate.Mapping.ByCode.Accessor.Property));

            Component(a => a.WorkAddress, z =>
            {
               
                z.Property(a => a.Province, a => a.Column("WorkAddress_Province"));
                z.Property(a => a.City, a => a.Column("WorkAddress_City"));
                z.Property(a => a.PostalCode, a => a.Column("WorkAddress_PostalCode"));
            });

            Component(a => a.HomeAddress, z =>
            {

                z.Property(a => a.Province, a => a.Column("HomeAddress_Province"));
                z.Property(a => a.City, a => a.Column("HomeAddress_City"));
                z.Property(a => a.PostalCode, a => a.Column("HomeAddress_PostalCode"));
            });
        }
    }
}
