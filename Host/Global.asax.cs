using Castle.Windsor;
using Framework.Core;
using Framework.Security;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Host
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

            var container = new WindsorContainer();
            DependencyConfigurator.Config(container);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new CastleControllerActivator(container));
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Guid token;
            var request = ((System.Web.HttpApplication)sender).Request;
            if (request.Headers["Token"] != null)
            {
                Guid.TryParse(request.Headers["Token"], out token);
                Authenticate(token.ToString());
            }
        }

        private void Authenticate(string token)
        {
            var client = new RestClient("http://localhost:5000/api");
            var request = new RestSharp.RestRequest("/Security/", RestSharp.Method.GET)
                .AddQueryParameter("token", token);
            try
            {
                var response = client.Execute(request);
                var context = ServiceLocator.Current.Resolve<IRequestContext>();
                var securityToken = JsonConvert.DeserializeObject<SecurityToken>(response.Content);
                context.FillRequestContext(securityToken.UserName, securityToken.Role, securityToken.Operations);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
