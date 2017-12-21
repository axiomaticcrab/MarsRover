using System.Collections.Generic;
using System.Linq;
using PlanetRover.Module.Common.Domain;

namespace PlanetRover.Module.Common.Manager
{
    public class DirectionManager : IDirectionManager
    {
        static readonly List<KeyValuePair<int, string>> DefaultDirectionsHolder = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(0,"East"),
            new KeyValuePair<int, string>(90,"North"),
            new KeyValuePair<int, string>(180,"West"),
            new KeyValuePair<int, string>(270,"South"),
        };

        public List<Direction> GetDefaultDirections()
        {
            var result = new List<Direction>();
            DefaultDirectionsHolder.ForEach(x =>
            {
                result.Add(new Direction(x.Value, x.Value.ToUpperInvariant().First().ToString(), x.Key));
            });
            return result;
        }
    }
}
