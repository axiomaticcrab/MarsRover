namespace PlanetRover.Module.Common.Exception
{
    public class RequiredParameterMissingException : ModuleLevelException
    {
        public RequiredParameterMissingException(string message) : base(message)
        {
        }
    }
}