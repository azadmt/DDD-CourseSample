using Castle.DynamicProxy;
using Framework.Core;
using Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Config
{
    public class SecurityInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {

            var authorizeAttributes = invocation.Method.GetCustomAttributes(typeof(AuthorizeAttribute), true).OfType<AuthorizeAttribute>().FirstOrDefault();
            if (authorizeAttributes != null)
            {
                var context = ServiceLocator.Current.Resolve<IRequestContext>();
                if (!context.Operations.Any(el => authorizeAttributes.Operations.Contains(el)))
                {
                    throw new UnauthorizedAccessException();
                }
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
            invocation.Proceed();
        }
    }
}
