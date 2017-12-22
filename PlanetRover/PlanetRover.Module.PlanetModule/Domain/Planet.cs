using System.Collections.Generic;
using System.Linq;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Exception;
using PlanetRover.Module.PlanetModule.Exception;

namespace PlanetRover.Module.PlanetModule.Domain
{
    public class Planet
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public string Name { get; protected set; }
        public List<Tile> Tiles { get; set; }


        public Planet With(int width, int height, string name)
        {
            if (width <= 0 || height <= 0) { throw new InvalidParameterException("size"); }
            if (string.IsNullOrEmpty(name)) { throw new RequiredParameterMissingException("name"); }

            Width = width;
            Height = height;
            Name = name;
            GenerateTiles();
            return this;
        }

        public bool HasTileAt(Position position)
        {
            if (Tiles != null) { return Tiles.Any(x => x.Position.Equals(position)); }
            return false;
        }

        public Tile GetTileAt(Position position)
        {
            if (HasTileAt(position))
            {
                return Tiles.First(x => x.Position.Equals(position));
            }
            throw new PlanetHasNoTileAtGivenPosition(position.ToString());
        }

        public Tile GetOriginTile()
        {
            return GetTileAt(new Position(0, 0));
        }

        protected void GenerateTiles()
        {
            Tiles = new List<Tile>();
            for (int i = 0; i < Width + 1; i++)
            {
                for (int j = 0; j < Height + 1; j++)
                {
                    Tiles.Add(new Tile(i, j));
                }
            }
        }
    }
}
