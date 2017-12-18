using System.Collections.Generic;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Module.PlanetModule.Domain
{
    public class Planet
    {
        #region IoC

        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public string Name { get; protected set; }
        public List<Tile> Tiles { get; set; }

        public Planet()
        {

        }

        #endregion
        
        public Planet With(int width, int height, string name)
        {
            if (width <= 0|| height <= 0) { throw new InvalidParameterException("size"); }
            if (string.IsNullOrEmpty(name)) { throw new RequiredParameterMissingException("name"); }

            Width = width;
            Height = height;
            Name = name;
            GenerateTiles();
            return this;
        }

        protected void GenerateTiles()
        {
            Tiles = new List<Tile>();
            for (int i = 0; i < Width+1; i++)
            {
                for (int j = 0; j < Height+1; j++)
                {
                    Tiles.Add(new Tile(i, j));
                }
            }
        }
    }
}
