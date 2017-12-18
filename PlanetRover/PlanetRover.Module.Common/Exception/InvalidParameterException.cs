namespace PlanetRover.Module.Common.Exception
{
    public class InvalidParameterException : ModuleLevelException
    {
        public InvalidParameterException(string message) : base(message)
        {
        }
    }
}