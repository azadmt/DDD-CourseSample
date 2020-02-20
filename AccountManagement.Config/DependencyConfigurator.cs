using AccountManagement.Application;
using AccountManagement.Application.Contract;
using AccountManagement.Controller.Controllers;
using AccountManagement.CustomerManagementACL;
using AccountManagement.Domain.Account;
using AccountManagement.Facade;
using AccountManagement.Facade.Contract;
using AccountManagement.Facade.Contract.EventHandler;
using AccountManagement.Persistence;
using AccountManagement.Persistence.Mapping;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Application;
using Framework.Config;
using Framework.Core;
using Framework.Persistence.NH;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AccountManagement.Config
{
    public class DependencyConfigurator
    {

        const string BoundedContextName = "AccountManagement";
        const string ConnectionStringName = BoundedContextName + "_DbConnection";
        const string SessionFactoryName = BoundedContextName + "_SessionFactory";
        const string SessionName = BoundedContextName + "_Session";
        const string UnitOfWorkName = BoundedContextName + "_UnitOfWork";
        public static void Config(IWindsorContainer windsorContainer)
        {
            RegisterCommandHandlers(windsorContainer);
            RegisterRepositories(windsorContainer);
            RegisterControllers(windsorContainer);
            RegisterDomainServices(windsorContainer);
            RegisterFacadeServices(windsorContainer);
         //   RegisterEventHandlers(windsorContainer);
            // RegisterMongoDependencies(windsorContainer);
            RegisterNHDependencies(windsorContainer);
        }


        private static void RegisterCommandHandlers(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<ICommandHandler<CreateAccountCommand>>()
                .ImplementedBy<CreateAccountCommandHandler>()
                .DependsOn(Dependency.OnComponent(typeof(IUnitOfWork), UnitOfWorkName))
                //.Interceptors<LoggingInterceptor>()
                .LifestylePerWebRequest());

        }


        private static void RegisterEventHandlers(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(
             Classes.FromAssemblyContaining<CustomerCreatedEventHandler>()
                 .BasedOn(typeof(IEventHandler<>))
                 .WithServiceAllInterfaces()
                 .LifestyleTransient());
        }

        private static void RegisterFacadeServices(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<IAccountService>()
                .ImplementedBy<AccountService>()
                .LifestylePerWebRequest());
        }

        private static void RegisterDomainServices(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<IAccountOwnerService>()
                .ImplementedBy<CustomerACL>()
                .LifestylePerWebRequest());

        }

        private static void RegisterRepositories(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<IAccountAggregateRepository>()
                .ImplementedBy<AccountAggregateRepository>()
                .DependsOn(Dependency.OnComponent(typeof(ISession), SessionName))
                .LifestylePerWebRequest());
        }


        private static void RegisterControllers(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Classes.FromAssemblyContaining(typeof(AccountController))
                .BasedOn<ApiController>()
                .LifestylePerWebRequest());
        }


        private static void RegisterNHDependencies(IWindsorContainer container)
        {
            container.Register(Component.For<ISessionFactory>()
                .UsingFactoryMethod<ISessionFactory>(a =>
                {
                    return SessionFactoryBuilder.Create(ConnectionStringName, typeof(AccountAggregateMapping).Assembly);
                }).Named(SessionFactoryName).LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod<ISession>(a =>
            {
                var factory = a.Resolve<ISessionFactory>(SessionFactoryName);
                return factory.OpenSession();
                //var connection = a.Resolve<IDbConnection>();
                //return factory.OpenSession((DbConnection)connection);
            }).Named(SessionName).LifestylePerWebRequest());
            //.LifestyleBoundTo<ICommandHandler>());

            container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<NHibernateUnitOfWork>()
                .Named(UnitOfWorkName)
                .DependsOn(Dependency.OnComponent(typeof(ISession), SessionName))
                .LifestylePerWebRequest());
        }
    }
}
