using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Customer
{
    public class Phone : EntityBase
    {
        string number;
        string title;
        Guid customerId;
        public Phone(string number, string title)
        {
            this.number = number;
            this.title = title;
        }
        public virtual Guid CustomerId { get { return customerId; } }
        public virtual string Title { get { return title; } }
        public virtual string Number { get { return number; } }
    }
}
