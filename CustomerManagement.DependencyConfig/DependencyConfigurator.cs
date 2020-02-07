using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CustomerManagement.Application;
using CustomerManagement.Application.Contract;
using CustomerManagement.Controller.Controllers;
using CustomerManagement.Customer;
using CustomerManagement.Facad;
using CustomerManagement.Facad.Contract;
using CustomerManagement.Persistence;
using CustomerManagement.Persistence.Mappings;
using Framework.Application;
using Framework.Config;
using Framework.Core;
using Framework.Persistence.NH;
using NHibernate;
using System.Web.Http;

namespace CustomerManagement.DependencyConfig
{
    public class DependencyConfigurator
    {

        const string BoundedContextName = "CustomerManagement";
        const string ConnectionStringName = BoundedContextName + "_DbConnection";
        const string SessionFactoryName = BoundedContextName + "_SessionFactory";
        const string SessionName = BoundedContextName + "_Session";
        const string UnitOfWorkName = BoundedContextName + "_UnitOfWork";
        public static void Config(IWindsorContainer windsorContainer)
        {
            RegisterCommandHandlers(windsorContainer);
            RegisterRepositories(windsorContainer);
            RegisterControllers(windsorContainer);
            RegisterFacadSerices(windsorContainer);
            RegisterNHDependencies(windsorContainer);
        }


        private static void RegisterCommandHandlers(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<ICommandHandler<RegisterCustomerCommand>>()
                .ImplementedBy<CustomerCommandHandlers>() 
                //.Interceptors<SecurityInterceptor>()
               // .Interceptors<LoggingInterceptor>()
               // .Proxy.Hook(new CommndHandlerLogHook())
                
                .DependsOn(Dependency.OnComponent(typeof(IUnitOfWork),UnitOfWorkName))               
                .LifestylePerWebRequest());

        }

        private static void RegisterFacadSerices(IWindsorContainer windsorContainer)
        {
            //windsorContainer.Register(
            //    Classes.FromAssemblyContaining<CustomerFacadService>()
            //    .BasedOn<IFacadeService>()
            //    .WithService.FromInterface()
            // //   .LifestyleBoundTo<ApiController>()// use a general interface IAppApi
            //    .Configure(a => a.Interceptors<SecurityInterceptor>()));

            windsorContainer.Register(
               Component.For<ICustomerFacadService>()
               .ImplementedBy<CustomerFacadService>()
               .Interceptors<LoggingInterceptor,SecurityInterceptor>()
               .LifestyleBoundTo<ApiController>());

        }

        private static void RegisterRepositories(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Component.For<ICustomerAggregateRepository>()
                .ImplementedBy<CustomerAggregateRepositoryNH>()
                .DependsOn(Dependency.OnComponent(typeof(ISession), SessionName))
                .LifestylePerWebRequest());

        }


        private static void RegisterControllers(IWindsorContainer windsorContainer)
        {
            windsorContainer.Register(Classes.FromAssemblyContaining(typeof(CustomerController))
                .BasedOn<ApiController>()
                .LifestylePerWebRequest());
        }

        private static void RegisterNHDependencies(IWindsorContainer container)
        {
            container.Register(Component.For<ISessionFactory>()
                .UsingFactoryMethod<ISessionFactory>(a =>
                {
                    return SessionFactoryBuilder.Create(ConnectionStringName, typeof(CustomerAggregateMapping).Assembly);
                }).Named(SessionFactoryName).LifestyleSingleton());

            container.Register(Component.For<ISession>().UsingFactoryMethod<ISession>(a =>
            {
                var factory = a.Resolve<ISessionFactory>(SessionFactoryName);
                // var connection = a.Resolve<IDbConnection>();
                // return factory.OpenSession((DbConnection)connection);
                return factory.OpenSession();
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
