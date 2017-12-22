using System;
using System.Linq;

namespace PlanetRover.Ui.ConsoleApplication.InputConverters.Impl
{
    class DefaultPositionConverter : IPositionConverter
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool IsValid { get; private set; }


        public IInputConverter Convert(string input)
        {
            var inputList = input.Split(' ');

            if (inputList.Length != 2)
            {
                IsValid = false;
            }
            else
            {
                try
                {
                    X = int.Parse(inputList.First());
                    Y = int.Parse(inputList.Last());
                    IsValid = true;
                }
                catch (Exception)
                {
                    IsValid = false;
                }
            }
            return this;
        }
    }
}