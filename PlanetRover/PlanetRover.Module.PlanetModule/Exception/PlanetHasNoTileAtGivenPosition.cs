using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Module.PlanetModule.Exception
{
    public class PlanetHasNoTileAtGivenPosition : ModuleLevelException
    {
        public PlanetHasNoTileAtGivenPosition(string message) : base(message)
        {
        }
    }
}
