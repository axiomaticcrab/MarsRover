using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PlanetRover.Configuration.Context;

namespace PlanetRover.Configuration.IoC.Installer
{
    public class ModuleContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IModuleContext>().ImplementedBy<ModuleContext>().LifestyleSingleton());
        }
    }
}
