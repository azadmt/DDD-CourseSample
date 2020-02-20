using AccountManagement.Application.Contract;
using CustomerManagement.Application.Contract;
using CustomerManagement.Domain.Contract;
using CustomerManagement.Facad.Contract;
using Framework.Application;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CustomerManagement.Facad
{
    public class CustomerFacadService : ICustomerFacadService
    {

        private ICommandBus commandbus;
        private IEventBus eventBus;
        public CustomerFacadService(ICommandBus commandbus, IEventBus eventBus)
        {
            this.commandbus = commandbus;
            this.eventBus = eventBus;
        }

        public Guid RegisterCustomer(RegisterCustomerCommand registerCustomerCommand)
        {
            Guid customerId = Guid.Empty;
            eventBus.Subscribe(new ActionHandler<CustomerCreatedEvent>(p =>
            customerId = p.CustomerId
            ));

            var opt = new TransactionOptions();
            opt.IsolationLevel = IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, opt))//AOP =>use PostSharp Or Castle Interceptor
            {
                commandbus.Dispatch(registerCustomerCommand);
                commandbus.Dispatch(new CreateAccountCommand() { OwnerId = customerId });
                scope.Complete();
                eventBus.Publish(new TransactionCommitedEvent());
            }
            return customerId;
        }



        /// <summary>
        /// در سیستم های یکپارچه اگر بخواهیم در یک درخواست چند اگریگیت را اضافه کنیم یا تغییر دهیم 
        ///  از  ترنزکشن اسکوپ برای کانسیستنسی استفاده میکنیم
        ///  اگر سیستم یک پارچه نباشد هر باندد کانتکست بر اساس ایونت پابلیش شده آن ایونت را هندل می کنند
        ///  (متد زیر می خواهد بعد از ثبت نام مشتری برای او یک حساب بانکی ایجاد کند)
        /// </summary>
        /// <param name="registerCustomerCommand"></param>
        //public Guid RegisterCustomer(RegisterCustomerCommand registerCustomerCommand)
        //{
        //    Guid customerId = Guid.Empty;
        //    eventBus.Subscribe(new ActionHandler<CustomerCreatedEvent>(p => customerId = p.Id));
        //    var opt = new TransactionOptions();
        //    opt.IsolationLevel = IsolationLevel.ReadCommitted;
        //    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, opt))
        //    {

        //        commandbus.Dispatch(registerCustomerCommand);
        //        //commandbus.Dispatch(new CreateAccountCommand() { CustomerNationalCode = command.NationalCode });
        //        scope.Complete();
        //    }
        //    return customerId;
        //}
    }
}
