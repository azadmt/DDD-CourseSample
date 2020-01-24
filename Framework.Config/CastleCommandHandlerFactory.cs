using Castle.Windsor;
using Framework.Application;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Config
{
    public class CastleCommandHandlerFactory : ICommandHandlerFactory
    {
        private IWindsorContainer container;
        public CastleCommandHandlerFactory(IWindsorContainer windsorContainer)
        {
            this.container = windsorContainer;
        }
        public ICommandHandler<T> CreateHandler<T>() where T : ICommand
        {
            return container.Resolve<ICommandHandler<T>>();
        }
    }
}
