using System;
using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Module.Common.Domain
{
    public class Tile : IPositionOwner
    {
        public Position Position { get; protected set; }

        public void SetPosition(Position position)
        {
            Position = position;
        }

        public Tile(int x, int y)
        {
            Position = new Position(x, y);
        }

        public Position FindNeighbourTilePosition(Direction direction)
        {
            if (direction == null) { throw new InvalidParameterException("direction"); }
            switch (direction.Degree)
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

    public interface ITileOwner
    {
        Tile CurrentTile { get; }

     void Move(Position position);
    }
}