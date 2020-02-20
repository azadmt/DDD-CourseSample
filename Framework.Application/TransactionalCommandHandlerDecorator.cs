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
        private IEventBus _eventBus;

        public TransactionalCommandHandlerDecorator(ICommandHandler<T> handler, IEventBus eventBus)
        {
            this._handler = handler;
            Uow = _handler.Uow;
            _eventBus = eventBus;
        }

        public IUnitOfWork Uow { get; private set; }

        public void Handle(T command)
        {
            Uow.Begin();
            _handler.Handle(command);
            Uow.Commit();
            if (System.Transactions.Transaction.Current == null)
            {
                _eventBus.Publish(new TransactionCommitedEvent());
            }
        }
    }
}
