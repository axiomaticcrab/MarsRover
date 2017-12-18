using System;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.PlanetModule.Domain;

namespace PlanetRover.Module.RoverModule.Domain
{
    public class Rover
    {
        public Location Location { get; set; }
        public Planet Planet { get; set; }

        public Location Land(Planet planet)
        {
            throw new NotImplementedException();
        }

        public Location Land(Planet planet, Position position)
        {
            throw new NotImplementedException();
        }

        public Location ChangeDirectionTo(Direction direction)
        {
            throw new NotImplementedException();
        }

        public Location Move()
        {
            throw new NotImplementedException();
        }
    }
}
