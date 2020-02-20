using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract
{
    public class CreateAccountCommand : ICommand
    {
        public Guid OwnerId { get; set; }

    }
}
