using System;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Exception;
using PlanetRover.Module.PlanetModule.Domain;
using PlanetRover.Module.RoverModule.Exception;

namespace PlanetRover.Module.RoverModule.Domain
{
    public class Rover
    {
        public Location Location { get; protected set; }
        public Planet Planet { get; protected set; }

        public Location Land(Planet planet, Direction direction)
        {
            return Land(planet, planet.GetOriginTile().Position, direction);
        }

        public Location Land(Planet planet, Position position, Direction direction)
        {
            return Land(planet, new Location().With(position, direction));
        }

        public Location Land(Planet planet, Location location)
        {
            if (planet == null) { throw new RequiredParameterMissingException("planet"); }
            if (location == null) { throw new RequiredParameterMissingException("location"); }

            if (planet.HasTileAt(location.Position))
            {
                Location = location;
                Planet = planet;
                return Location;
            }
            throw new CannotLandToGivenTileBecauseTheTileIsNotExist(location.Position.ToString());
        }

        public void ChangeDirectionTo(Direction direction)
        {
            Location.SetDirection(direction);
        }

        public Location Move()
        {
            var tilePositionToMove = Planet.GetTileAt(Location.Position).FindNeighbourTilePosition(Location.Direction);

            if (Planet.HasTileAt(tilePositionToMove))
            {
                Location.SetPosition(tilePositionToMove);
                return Location;
            }
            throw new CannotLandToGivenTileBecauseTheTileIsNotExist(tilePositionToMove.ToString());
        }
    }
}
