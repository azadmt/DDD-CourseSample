using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IRequestContext
    {
        DateTime Created { get; }
        Guid TraceId { get; }
        string RoleName { get; }
        string UserName { get; }
        int[] Operations { get; }

        void FillRequestContext(string roleName, string UserName, int[] operations);
    }

    public class RequestContext : IRequestContext
    {
        public DateTime Created { get; private set; }

        public Guid TraceId { get; private set; }

        public string RoleName { get; private set; }

        public string UserName { get; private set; }

        public int[] Operations { get; private set; }

        public void FillRequestContext(string roleName, string userName, int[] operations)
        {
            RoleName = roleName;
            UserName = userName;
            Operations = operations;
        }
    }
}
