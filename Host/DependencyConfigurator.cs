using Castle.Windsor;
using Framework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Host
{
    public class DependencyConfigurator
    {
        public static void Config(IWindsorContainer container)
        {
            Framework.Config.DependencyConfigurator.Config(container);
            AccountManagement.Config.DependencyConfigurator.Config(container);
            CustomerManagement.DependencyConfig.DependencyConfigurator.Config(container);
            ServiceLocator.Initial(container.Resolve<IContainer>());
        }
    }
} 