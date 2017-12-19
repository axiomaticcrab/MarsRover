using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Module.RoverModule.Exception
{
    public class CannotLandToGivenTileBecauseTheTileIsNotExist : ModuleLevelException
    {
        public CannotLandToGivenTileBecauseTheTileIsNotExist(string message) : base(message)
        {
        }
    }
}
