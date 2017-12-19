using System;

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

        public override string ToString()
        {
            return String.Format("X:{0} - Y:{1}", X, Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Position)
            {
                var position = (Position)obj;

                if (X == position.X && Y == position.Y)
                {
                    return true;
                }
                return false;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}