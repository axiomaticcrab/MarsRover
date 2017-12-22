namespace PlanetRover.Module.Common.Domain
{
    public static class DegreeHelper
    {
        public static int Add(this int degree, int amount)
        {
            var result = degree + amount;

            if (result==360)
            {
                result = 0;
            }

            if (result<0)
            {
                result = 360 + result;
            }

            return result;
        }
    }
}
