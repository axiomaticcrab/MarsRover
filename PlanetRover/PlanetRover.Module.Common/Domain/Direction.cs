using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Module.Common.Domain
{
    public class Direction
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Degree { get; set; }

        public Direction(string name, string code, int degree)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new RequiredParameterMissingException("name");
            }

            if (string.IsNullOrEmpty(code))
            {
                throw new RequiredParameterMissingException("code");
            }

            Name = name;
            Code = code;
            Degree = degree;
        }
    }

    public interface IDirectionOwner
    {
        Direction Direction { get; }

        void SetDirection(Direction direction);
    }
}
