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
       // private IUnitOfWork uow;
        public CommandBus(ICommandHandlerFactory factory/*, IUnitOfWork uow*/)
        {
            this._factory = factory;
           // this.uow = uow;
        }

        public void Dispatch<T>(T command) where T : ICommand
        {
            var handler = _factory.CreateHandler<T>();
            try
            {

              //  uow.Begin();//????
              
                handler.Uow.Begin();
               // var transactionalHandler = new TransactionalCommandHandlerDecorator<T>(handler, uow);
                handler.Handle(command);
                handler.Uow.Commit();
                //  uow.Commit();

            }
            catch (Exception ex)
            {

                handler.Uow.Rollback();
                throw ex;
            }
           //TODO: release command handler
        }
    }
}
