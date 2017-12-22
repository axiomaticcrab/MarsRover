using System.Collections.Generic;

namespace PlanetRover.Ui.ConsoleApplication.InputConverters
{
    interface ICommandConverter : IInputConverter
    {
        List<string> CommandCodes { get; }

    }
}
