using Banking.ReadModel.QueryService;
using Banking.ReadModel.QueryService.Contract.OperationContract;
using Banking.ReadModel.QueryService.EventHandlers.AccountManagement;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Banking.ReadModel.DependencyConfig
{
    public class DependencyConfigurator
    {
        public static void Config(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<IAccountQueryService>().ImplementedBy<AccountQueryService>());

            windsorContainer.AddMassTransit(x =>
            {
                x.AddConsumers(typeof(AccountCreatedConsumer).Assembly);
            });



        }
    }
}
