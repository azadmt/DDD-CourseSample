using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Host
{
    public class CastleControllerActivator : IHttpControllerActivator
    {
        private IWindsorContainer windsorContainer;
        public CastleControllerActivator(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)windsorContainer.Resolve(controllerType);
        }
    }
}