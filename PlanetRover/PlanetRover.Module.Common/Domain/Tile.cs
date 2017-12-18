using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Module.Common.Domain
{
    public class Tile
    {
        public Position Position { get; protected set; }

        public Tile(Position position)
        {
            Position = position;
        }

        public Tile(int x, int y)
        {
            Position = new Position(x, y);
        }

        public Position FindNeighbourTilePosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new Position(Position.X, Position.Y + 1);
                case Direction.South:
                    return new Position(Position.X, Position.Y - 1);
                case Direction.East:
                    return new Position(Position.X + 1, Position.Y);
                case Direction.West:
                    return new Position(Position.X - 1, Position.Y);
            }
            throw new InvalidParameterException("direction");
        }
    }
}