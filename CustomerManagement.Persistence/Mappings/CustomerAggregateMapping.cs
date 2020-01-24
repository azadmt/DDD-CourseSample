using CustomerManagement.Customer;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Persistence.Mappings
{
    public class CustomerAggregateMapping : ClassMapping<CustomerAggregate>
    {
        public CustomerAggregateMapping()
        {
            Table("Customers");
            Id(p => p.Id, p => p.Access(Accessor.Field));

            Property(p => p.FirstName, p => p.Access(NHibernate.Mapping.ByCode.Accessor.Field));
            Property(p => p.LastName, p => p.Access(NHibernate.Mapping.ByCode.Accessor.Field));

            Component(p => p.NationalCode, z =>
            {
                // z.Access(Accessor.Field);
                z.Property(a => a.Code, a =>
                {
                    a.Column("NationalCode");
                });
            });

            Component(p => p.HomeAddress, z =>
            {
                // z.Access(Accessor.Field);
                z.Property(a => a.City, a =>
                {
                    a.Column("HomeAddress_City");
                    a.Access(Accessor.Field);
                }
                );
                z.Property(a => a.Province, a =>
                {
                    a.Access(Accessor.Field);
                    a.Column("HomeAddress_Province");
                });

                z.Property(a => a.PostalCode, a =>
                {
                    a.Access(Accessor.Field);
                    a.Column("HomeAddress_PostalCode");
                });
            });

            Component(p => p.WorkAddress, z =>
            {
                //  z.Access(Accessor.Field);
                z.Property(a => a.City, a =>
                {
                    a.Access(Accessor.Field);
                    a.Column("WorkAddress_City");
                });
                z.Property(a => a.Province, a =>
                {
                    a.Access(Accessor.Field);
                    a.Column("WorkAddress_Province");
                });

                z.Property(a => a.PostalCode, a =>
                {
                    a.Access(Accessor.Field);
                    a.Column("WorkAddress_PostalCode");
                });
            });
        }
    }
}
