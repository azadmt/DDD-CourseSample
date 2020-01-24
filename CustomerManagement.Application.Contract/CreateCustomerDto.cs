using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Contract
{
    //public class CreateCustomerDto
    //{
    //    public string FirstName { get; set; }//EF does not support field !!!
    //    public string LastName { get; set; }//EF does not support field !!!

    //    public string HomeAddress_PostalCode { get; private set; }
    //    public string HomeAddress_City { get; private set; }
    //    public string HomeAddress_Province { get; private set; }


    //    public string WorkAddress_PostalCode { get; private set; }
    //    public string WorkAddress_City { get; private set; }
    //    public string WorkAddress_Province { get; private set; }

    //}

    public class RegisterCustomerCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }

        public string HomeAddress_PostalCode { get;  set; }
        public string HomeAddress_City { get;  set; }
        public string HomeAddress_Province { get;  set; }


        public string WorkAddress_PostalCode { get;  set; }
        public string WorkAddress_City { get;  set; }
        public string WorkAddress_Province { get;  set; }

    }

    public class RemoveCustomerCommand : ICommand
    {
        public Guid Id { get; set; }
    }

    public class UpdateCustomerCommand : ICommand
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string HomeAddress_PostalCode { get; private set; }
        public string HomeAddress_City { get; private set; }
        public string HomeAddress_Province { get; private set; }


        public string WorkAddress_PostalCode { get; private set; }
        public string WorkAddress_City { get; private set; }
        public string WorkAddress_Province { get; private set; }

    }
}
