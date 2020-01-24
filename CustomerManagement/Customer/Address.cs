using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Customer
{
    public class Address : ValueObject<Address>
    {
        string postalCode;
        string city;
        string province;
        public Address(string postalCode, string city, string province)
        {
            this.postalCode = postalCode;
            this.city = city;
            this.province = province;
        }
        protected Address() //protected for NH
        {

        }
        public virtual string PostalCode { get {return postalCode; } }// Value Object?
        public virtual string City { get { return city; } }
        public virtual string Province { get { return province; } } //protected for NH

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new object[] { PostalCode, City, Province };
        }
    }
}
