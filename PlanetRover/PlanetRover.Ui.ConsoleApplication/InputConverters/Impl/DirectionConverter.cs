using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetRover.Ui.ConsoleApplication.InputConverters.Impl
{
    class DirectionConverter : IDirectionConverter
    {
        private readonly Dictionary<Func<string, bool>, Func<int>> directions = new Dictionary<Func<string, bool>, Func<int>>
        {
            {x => x == "E", () => 0},
            {x => x == "N", () => 90},
            {x => x == "W", () => 180},
            {x => x == "S", () => 270}
        };

        private bool isValid;
        public bool IsValid { get { return isValid; } }

        public int Degree { get; private set; }

        public IInputConverter Convert(string input)
        {
            Degree = directions.First(x => x.Key(input)).Value.Invoke();
            isValid = true;
            return this;
        }


    }
}