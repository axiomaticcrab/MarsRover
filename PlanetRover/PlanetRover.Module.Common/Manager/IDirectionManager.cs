using System.Collections.Generic;
using PlanetRover.Module.Common.Domain;

namespace PlanetRover.Module.Common.Manager
{
    public interface IDirectionManager
    {
        List<Direction> GetDirections();
    }
}