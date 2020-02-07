using Castle.DynamicProxy;
using System;
using System.Reflection;

namespace Framework.Config
{
    public class CommndHandlerLogHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
           // throw new NotImplementedException();
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
          //  throw new NotImplementedException();
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            
          //  return type.GetInterface("ICommandHandler") != null && methodInfo.Name == "Handle";
            return methodInfo.Name == "Handle";
        }
    }
}
