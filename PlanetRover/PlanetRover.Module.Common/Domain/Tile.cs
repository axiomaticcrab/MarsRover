using System;
using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Module.Common.Domain
{
    public class Tile
    {
        public Position Position { get; protected set; }

        public Tile(int x, int y)
        {
            Position = new Position(x, y);
        }

        public Position FindNeighbourTilePosition(Direction direction)
        {
            if (direction == null) { throw new InvalidParameterException("direction"); }
            switch (direction.DegreeInRadian)
            {
                case 0:
                    return new Position(Position.X + 1, Position.Y);
                case 90:
                    return new Position(Position.X, Position.Y + 1);
                case 180:
                    return new Position(Position.X - 1, Position.Y);
                case 270:
                    return new Position(Position.X, Position.Y - 1);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}