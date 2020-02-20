using CustomerManagement.Domain.Contract;
using Framework.Core;
using Framework.Domain;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Customer
{
    public class CustomerAggregate :Entity, IAggregateRoot
    {
        string firstName;
        string lastName;

        public virtual string FirstName { get { return firstName; } }//EF does not support field !!!
        public virtual string LastName { get { return lastName; } }//EF does not support field !!!
        public virtual NationalCode NationalCode { get; protected set; }//EF does not support field !!!


        public virtual Address HomeAddress { get; protected set; }
        public virtual Address WorkAddress { get; protected set; }
        public virtual IEventBus EventBus { get; protected set; }

        public CustomerAggregate(string firstName, string lastName, string nationalCode, Address homeAddress, Address workAddress, IEventBus eventBus)
        {
            EventBus = eventBus;
            this.firstName = firstName;
            this.lastName = lastName;
            HomeAddress = homeAddress;
            WorkAddress = workAddress;
            NationalCode = new NationalCode(nationalCode);

            EventBus.Publish(new CustomerCreatedEvent(
                Id, FirstName, LastName,
                HomeAddress.PostalCode, HomeAddress.City, HomeAddress.Province, 
                WorkAddress.PostalCode, WorkAddress.City, WorkAddress.Province));
        }

        protected CustomerAggregate()
        {

        }

        public virtual void ChangeNationalCode(NationalCode newNationalCode)
        {
            NationalCode = newNationalCode;
            EventBus.Publish(new CustomerNationalCodeChanged(Id, NationalCode.Code));
        }
    }
}
