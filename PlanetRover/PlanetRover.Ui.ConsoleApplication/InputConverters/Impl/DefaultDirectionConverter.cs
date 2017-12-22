using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetRover.Ui.ConsoleApplication.InputConverters.Impl
{
    class DefaultDirectionConverter : IDirectionConverter
    {
        private readonly Dictionary<Func<string, bool>, Func<float>> directions = new Dictionary<Func<string, bool>, Func<float>>
        {
            {x => x == "E", () => { return 0; } },
            {x => x == "N", () => { return 90; }},
            {x => x == "W", () => { return 180; }},
            {x => x == "S", () => { return 270; }}
        };

        private bool isValid;
        public bool IsValid { get { return isValid; } }

        public float Degree { get; private set; }

        public IInputConverter Convert(string input)
        {
            Degree = directions.First(x => x.Key(input)).Value.Invoke();
            isValid = true;
            return this;
        }


    }
}