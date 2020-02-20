using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Account
{
   public interface IAccountOwnerService
    {
        AccountOwner GetAccountOwner(Guid ownerId);
    }
}
