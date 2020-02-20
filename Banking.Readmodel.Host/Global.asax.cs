using AccountManagement.Domain.Contract;
using Banking.ReadModel.QueryService.EventHandlers.AccountManagement;
using Banking.ReadModel.QueryService.EventHandlers.CustomerManagement;
using CustomerManagement.Domain.Contract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Banking.Readmodel.Host
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                sbc.Host("rabbitmq://localhost");


                sbc.ReceiveEndpoint(nameof(AccountCreatedEvent).ToString(), ep =>
                {
                    ep.Consumer<AccountCreatedConsumer>();
                });


                sbc.ReceiveEndpoint(nameof(CustomerCreatedEvent).ToString(), ep =>
                {
                    ep.Consumer<CustomerCreatedConsumer>();
                });
            });

            bus.StartAsync();
        }
    }
}
