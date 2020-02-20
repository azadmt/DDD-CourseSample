using Banking.ReadModel.QueryService.Contract.DataContract;
using CustomerManagement.Domain.Contract;
using Framework.Core;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ReadModel.QueryService.EventHandlers.CustomerManagement
{
    public class CustomerCreatedConsumer : IConsumer<CustomerCreatedEvent>
    {
        public async Task Consume(ConsumeContext<CustomerCreatedEvent> context)
        {
            using (ReadModelContext db = new ReadModelContext())
            {
                    db.Customers.Add(new CustomerDto() { 
                        Id = context.Message.CustomerId,
                        FirstName = context.Message.FirstName, 
                        LastName = context.Message.LastName,
                        WorkAddressCity = context.Message.WorkAddressCity,
                        WorkAddressPostalCode= context.Message.WorkAddressPostalCode,
                        WorkAddressProvince= context.Message.WorkAddressProvince ,
                        HomeAddressCity = context.Message.HomeAddressCity,
                        HomeAddressPostalCode = context.Message.HomeAddressPostalCode,
                        HomeAddressProvince = context.Message.HomeAddressProvince,
                    });
                    db.SaveChanges();
            }
        }
    }
}
