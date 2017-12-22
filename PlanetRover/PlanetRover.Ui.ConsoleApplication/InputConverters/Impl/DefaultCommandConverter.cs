using System.Collections.Generic;
using System.Linq;

namespace PlanetRover.Ui.ConsoleApplication.InputConverters.Impl
{
    class DefaultCommandConverter : ICommandConverter
    {
        public bool IsValid { get { return (CommandCodes != null) ? CommandCodes.Any() : false; } }
        public IInputConverter Convert(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                CommandCodes = new List<string>();
                foreach (var commandCode in input)
                {
                    CommandCodes.Add(commandCode.ToString());
                }
            }
            return this;
        }

        public List<string> CommandCodes { get; private set; }
    }
}
