using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private ICommandHandler<T> _handler;

        public IUnitOfWork Uow { get; private set; }

        public TransactionalCommandHandlerDecorator(ICommandHandler<T> handler, IUnitOfWork unitOfWork)
        {
            this._handler = handler;
            Uow = handler.Uow;
        }

        public void Handle(T command)
        {
            Uow.Begin();
            _handler.Handle(command);
            Uow.Commit();
        }
    }
}
