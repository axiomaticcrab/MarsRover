using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Module.Common.Domain
{
    public class Location
    {
        public Position Position { get; protected set; }
        public Direction Direction { get; protected set; }

        public Location()
        {

        }

        public Location With(Position position, Direction direction)
        {
            SetPosition(position);
            SetDirection(direction);
            return this;
        }

        public void SetDirection(Direction direction)
        {
            if (direction == default(Direction)) { throw new RequiredParameterMissingException("direction"); }
            Direction = direction;
        }

        public void SetPosition(Position position)
        {
            if (position == null) { throw new RequiredParameterMissingException("position"); }
            Position = position;
        }
    }
}