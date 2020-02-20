using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Facilities;
using Framework.Core;
using Framework.Application;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MassTransit;
using Framework.ServiceBus.MassTransit;

namespace Framework.Config
{
    public class DependencyConfigurator
    {
        public static void Config(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<SecurityInterceptor>());
            windsorContainer.Register(Component.For<LoggingInterceptor>());
            windsorContainer.Register(Component.For<IRequestContext>().ImplementedBy<RequestContext>().LifestylePerWebRequest());// Install-Package Castle.Facilities.AspNet.SystemWeb
            windsorContainer.Register(Component.For<IEventBus>().ImplementedBy<EventAggregator>().LifestylePerWebRequest());// Install-Package Castle.Facilities.AspNet.SystemWeb
            windsorContainer.Register(Component.For<ILogger>().ImplementedBy<Logger>().LifestyleSingleton());// Install-Package Castle.Facilities.AspNet.SystemWeb
            windsorContainer.Register(Component.For<ISerializer>().ImplementedBy<JsonSerializer>().LifestyleSingleton());// Install-Package Castle.Facilities.AspNet.SystemWeb
            windsorContainer.Register(Component.For<ICommandBus>().ImplementedBy<CommandBus>().LifestylePerWebRequest());// Install-Package Castle.Facilities.AspNet.SystemWeb
            windsorContainer.Register(Component.For<IContainer>().ImplementedBy<Container>().UsingFactoryMethod<Container>(p =>
            {
                return new Container(windsorContainer);
            }));


            windsorContainer.Register(Component.For<IBusControl>().UsingFactoryMethod<IBusControl>(p =>
            {
                return Bus.Factory.CreateUsingRabbitMq(sbc =>
                {
                    sbc.Host("rabbitmq://localhost");// read from config

                });
            }));

            windsorContainer.Register(Component.For<IEnterpriseServiceBus>().ImplementedBy<MassTransitServiceBus>());



            windsorContainer.Register(Component.For<ICommandHandlerFactory>().ImplementedBy<CastleCommandHandlerFactory>()
                .UsingFactoryMethod<CastleCommandHandlerFactory>(p =>
                  {
                      return new CastleCommandHandlerFactory(windsorContainer);
                  })

                .LifestyleSingleton());// Install-Package Castle.Facilities.AspNet.SystemWeb

            windsorContainer.Register(Component.For<IDbConnection>().UsingFactoryMethod<SqlConnection>(a =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }).LifestylePerWebRequest().OnDestroy(a =>
            {
                a.Close();
            }).Forward<DbConnection>());

       
        }

    }
}
