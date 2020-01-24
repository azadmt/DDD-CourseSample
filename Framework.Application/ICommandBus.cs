using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{

    public interface ICommand
    {

    }

    public interface ICommandBus
    {
        void Dispatch<T>(T command) where T : ICommand;
    }
}
