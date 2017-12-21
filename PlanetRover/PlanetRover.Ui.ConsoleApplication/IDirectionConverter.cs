using System.Collections.Generic;
using PlanetRover.Module.Common.Domain;

namespace PlanetRover.Ui.ConsoleApplication
{
    interface IDirectionConverter : IInputConverter
    {
        List<DirectionMapping> DirectionMappings { get; }
        Direction Direction { get; }
    }
}