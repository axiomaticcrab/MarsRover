using System.Collections.Generic;
using System.Linq;

namespace PlanetRover.Ui.ConsoleApplication.InputConverters.Impl
{
    class CommandConverter : ICommandConverter
    {
        public bool IsValid { get { return (Commands != null) ? Commands.Any() : false; } }
        public IInputConverter Convert(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Commands = new List<string>();
                foreach (var commandCode in input)
                {
                    Commands.Add(commandCode.ToString());
                }
            }
            return this;
        }

        public List<string> Commands { get; private set; }
    }
}
