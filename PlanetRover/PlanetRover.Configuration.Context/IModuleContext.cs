using Castle.Windsor;

namespace PlanetRover.Configuration.Context
{
    public interface IModuleContext
    {
        T Resolve<T>();
    }

    public class ModuleContext: IModuleContext
    {
        private readonly IWindsorContainer container;

        public ModuleContext(IWindsorContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
