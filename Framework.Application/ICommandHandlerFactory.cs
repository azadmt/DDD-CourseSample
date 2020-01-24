using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public interface ICommandHandlerFactory
    {

        ICommandHandler<T> CreateHandler<T>() where T : ICommand;
    }


}
