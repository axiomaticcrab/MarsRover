using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PlanetRover.Configuration.IoC.Installer;

namespace PlanetRover.Configuration.IoC.Factory
{
    public class ContainerFactory
    {
        private static IWindsorContainer container;
        private static readonly object Syncroot = new object();

        public ContainerFactory()
        {

            if (container == null)
            {
                lock (Syncroot)
                {
                    if (container == null)
                    {
                        Register();
                    }
                }
            }
        }

        public IWindsorContainer Get()
        {
            return container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public ContainerFactory ReInstall()
        {
            lock (Syncroot)
            {
                container = null;
                Register();
            }
            return this;
        }

        private void Register()
        {
            container = new WindsorContainer();
            container.Register(Component.For<IWindsorContainer>().Instance(container));
            
            RegisterModules(container);
        }

        private void RegisterModules(IWindsorContainer container)
        {
            container.Install(new ModuleInstaller());
        }
    }
}
