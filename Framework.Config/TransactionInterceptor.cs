using Castle.DynamicProxy;
using System.Transactions;

namespace Framework.Config
{
    public class TransactionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var opt = new TransactionOptions();
            opt.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, opt))
            {
                invocation.Proceed();
                scope.Complete();
            }
        }
    }
}
