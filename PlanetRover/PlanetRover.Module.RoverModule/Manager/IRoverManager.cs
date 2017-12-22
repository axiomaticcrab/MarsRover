using PlanetRover.Configuration.Context;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.PlanetModule.Domain;
using PlanetRover.Module.RoverModule.Domain;

namespace PlanetRover.Module.RoverModule.Manager
{
    public interface IRoverManager
    {
        Rover CreateRoverAndLand(Planet planet, Location location);
    }
    public class RoverManager : IRoverManager
    {
        private readonly IModuleContext context;

        public RoverManager(IModuleContext context)
        {
            this.context = context;
        }


        public Rover CreateRoverAndLand(Planet planet, Location location)
        {
            var rover = context.Resolve<Rover>();
            rover.Land(planet, location);
            return rover;
        }
    }
}
