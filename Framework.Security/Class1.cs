using Framework.Core;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Security
{
    [Serializable]
    public sealed class AuthorizeAttribute : OnMethodBoundaryAspect
    {
        public AuthorizeAttribute(params int[] operations)
        {
            Operations = operations;
        }

        private int[] Operations { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var authorizationService = ServiceLocator.Current.Resolve<IAuthorizationService>();
            authorizationService.Authorize(Operations);
        }
    }

    public interface IAuthorizationService
    {
        void Authorize(params int[] operations);
    }

    public class AuthorizationService : IAuthorizationService
    {
        public void Authorize(params int[] operations)
        {
            //TODO
        }
    }
}
