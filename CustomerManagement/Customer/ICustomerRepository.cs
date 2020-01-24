using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Customer
{
    public interface ICustomerAggregateRepository
    {
        CustomerAggregate Get(Guid id);
        CustomerAggregate FindBy(string nationalCode);
        void Remove(Guid id);
        void Create(CustomerAggregate customerAggregate);
        void Update(CustomerAggregate customerAggregate);
    }
}
