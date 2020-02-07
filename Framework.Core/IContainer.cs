using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IContainer
    {
        T Resolve<T>();

        T Resolve<T>(Func<T, bool> selector);

        T Resolve<T>(string objectName);

        T TryResolve<T>();

        IEnumerable<T> ResolveAll<T>();
    }
}
