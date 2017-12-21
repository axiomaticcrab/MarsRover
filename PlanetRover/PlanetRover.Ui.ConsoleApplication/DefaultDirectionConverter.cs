using System;
using System.Collections.Generic;
using System.Linq;
using PlanetRover.Module.Common.Domain;

namespace PlanetRover.Ui.ConsoleApplication
{
    class DefaultDirectionConverter : IDirectionConverter
    {
        public bool IsValid { get { return Direction != default(Direction); } }

        private List<DirectionMapping> directionMappings;
        public List<DirectionMapping> DirectionMappings
        {
            get
            {
                if (directionMappings != null)
                {
                    return directionMappings;
                }
                else
                {
                    directionMappings = new List<DirectionMapping>();

                    Enum.GetNames(typeof(Direction)).ToList().ForEach(x =>
                    {
                        directionMappings.Add(new DirectionMapping
                        {
                            Direction = (Direction)Enum.Parse(typeof(Direction), x),
                            Representation = x.First(),
                        });
                    });
                    return directionMappings;
                }
            } 
        }

        public Direction Direction { get; private set; }

        public IInputConverter Convert(string input)
        {
            if (DirectionMappings.Any(x => x.Representation.ToString() == input.ToUpperInvariant()))
            {
                Direction = DirectionMappings.First(x => x.Representation.ToString() == input).Direction;
            }
            return this;
        }
    }
}