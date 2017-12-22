using PlanetRover.Module.PlanetModule.Domain;

namespace PlanetRover.Module.PlanetModule.Manager
{
    public class PlanetManager : IPlanetManager
    {
        public Planet CreatePlanet(int width, int height, string name)
        {
            return new Planet().With(width, height, name);
        }
    }
}