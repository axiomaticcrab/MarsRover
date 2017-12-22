using PlanetRover.Module.PlanetModule.Domain;

namespace PlanetRover.Module.PlanetModule.Manager
{
    public interface IPlanetManager
    {
        Planet CreatePlanet(int width, int height, string name);
    }
}
