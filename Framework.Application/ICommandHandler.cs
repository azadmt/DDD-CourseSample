using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class  MyAttribiute:Attribute
    {

    }
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        IUnitOfWork Uow { get; }
        void Handle(T command);
    }

    public abstract class CommandHandler
    {
        public IUnitOfWork Uow { get; private set; }
        public CommandHandler(IUnitOfWork uow)
        {
            Uow = uow;
        }
    }
}
