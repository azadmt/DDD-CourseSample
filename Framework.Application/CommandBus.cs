using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Application
{
    public class CommandBus : ICommandBus
    {
        private ICommandHandlerFactory _factory;
        private IEventBus _eventBus;
        public CommandBus(ICommandHandlerFactory factory, IEventBus eventBus)
        {
            this._factory = factory;
            this._eventBus = eventBus;
        }

        public void Dispatch<T>(T command) where T : ICommand
        {
            var handler = _factory.CreateHandler<T>();
            try
            {
              //  handler.Uow.Begin();
                handler = new TransactionalCommandHandlerDecorator<T>(handler, _eventBus);// Decorate command handler
                handler.Handle(command);
             //   handler.Uow.Commit();
                //if (System.Transactions.Transaction.Current == null)
                //{
                //    _eventBus.Publish(new TransactionCommitedEvent());
                //}            
            }
            catch (Exception ex)
            {
                handler.Uow.Rollback();
                throw ex;
            }

        }
    }
}
