using System;
using System.Linq;

namespace PlanetRover.Ui.ConsoleApplication
{
    class DefaultRoverInfoConverter : IRoverInfoConverter
    {
        public bool IsValid { get { return PositionConverter.IsValid && DirectionConverter.IsValid; } }

        public IInputConverter Convert(string input)
        {
            if (!string.IsNullOrEmpty(input)&&!string.IsNullOrWhiteSpace(input))
            {
                var inputList = input.Split(' ');
                if (inputList.Length==3)
                {
                    PositionConverter.Convert(String.Join(" ", inputList.Take(2).ToArray()));
                    DirectionConverter.Convert(inputList.Last());
                }
            }
            return this;
        }

        public IPositionConverter PositionConverter { get; }
        public IDirectionConverter DirectionConverter { get; }

        public DefaultRoverInfoConverter()
        {
            PositionConverter = new DefaultPositionConverter();
            DirectionConverter = new DefaultDirectionConverter();
        }
    }
}