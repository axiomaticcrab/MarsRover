namespace PlanetRover.Module.Common.Domain
{
    public class Position
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}