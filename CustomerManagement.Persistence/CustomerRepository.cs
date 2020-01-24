using CustomerManagement.Customer;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Persistence
{
    public class CustomerAggregateRepositoryNH : ICustomerAggregateRepository
    {
        private ISession session;
        public CustomerAggregateRepositoryNH(ISession session)
        {
            this.session = session;
        }

        public void Create(CustomerAggregate customerAggregate)
        {
            session.Save(customerAggregate);
        }

        public CustomerAggregate Get(Guid id)
        {
            return session.Query<CustomerAggregate>().Single(p => p.Id == id);
        }

        public CustomerAggregate FindBy(string nationalCode)
        {
            return session.Query<CustomerAggregate>().Single(p => p.NationalCode == new NationalCode(nationalCode));
        }

        public void Remove(Guid id)
        {
            var aggrigate= session.Query<CustomerAggregate>().Single(p => p.Id == id);
            session.Delete(aggrigate);
        }

        public void Update(CustomerAggregate customerAggregate)
        {
            throw new NotImplementedException();
        }
    }
}
