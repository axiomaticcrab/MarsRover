using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PlanetRover.Module.CommandModule.Domain.Command;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Manager;
using PlanetRover.Module.PlanetModule.Domain;
using PlanetRover.Module.RoverModule.Domain;

namespace PlanetRover.Configuration.IoC.Installer
{
    public class ModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterCommon(container);
            RegisterCommandModule(container);
            RegisterPlanetModule(container);
            RegisterRoverModule(container);
        }

        private void RegisterCommon(IWindsorContainer container)
        {
            container.Register(
                Types.FromAssemblyContaining(typeof(Direction)).Pick().WithServiceAllInterfaces().LifestyleTransient());
        }

        private void RegisterCommandModule(IWindsorContainer container)
        {
            container.Register(
                Types.FromAssemblyContaining(typeof(Command)).Pick().WithServiceAllInterfaces().LifestyleTransient());
        }

        private void RegisterPlanetModule(IWindsorContainer container)
        {
            container.Register(
                Types.FromAssemblyContaining(typeof(Planet)).Pick().WithServiceAllInterfaces().LifestyleTransient());
        }

        private void RegisterRoverModule(IWindsorContainer container)
        {
            container.Register(
                Types.FromAssemblyContaining(typeof(Rover)).Pick().WithServiceAllInterfaces().LifestyleTransient());
        }
    }
}
