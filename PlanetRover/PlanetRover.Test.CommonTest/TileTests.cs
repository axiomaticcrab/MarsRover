using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Exception;

namespace PlanetRover.Test.CommonTest
{
    [TestClass]
    public class TileTests
    {
        #region Feature : FindNeighbourTilePosition

        [TestMethod]
        public void Should_FindNeighbourTile_When_RequestedDirectionIsNorth()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            var neighbourTilePosition = tile.FindNeighbourTilePosition(Direction.North);

            Assert.AreEqual(y + 1, neighbourTilePosition.Y);
            Assert.AreEqual(x, neighbourTilePosition.X);
        }

        [TestMethod]
        public void Should_FindNeighbourTile_When_RequestedDirectionIsSouth()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            var neighbourTilePosition = tile.FindNeighbourTilePosition(Direction.South);

            Assert.AreEqual(y - 1, neighbourTilePosition.Y);
            Assert.AreEqual(x, neighbourTilePosition.X);
        }

        [TestMethod]
        public void Should_FindNeighbourTile_When_RequestedDirectionIsEast()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            var neighbourTilePosition = tile.FindNeighbourTilePosition(Direction.East);

            Assert.AreEqual(y, neighbourTilePosition.Y);
            Assert.AreEqual(x + 1, neighbourTilePosition.X);
        }

        [TestMethod]
        public void Should_FindNeighbourTile_When_RequestedDirectionIsWest()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            var neighbourTilePosition = tile.FindNeighbourTilePosition(Direction.West);

            Assert.AreEqual(y, neighbourTilePosition.Y);
            Assert.AreEqual(x - 1, neighbourTilePosition.X);
        }

        [TestMethod]
        [ExpectedException(typeof (InvalidParameterException))]
        public void Sould_ThrowInvalidParameterException_When_RequestedDirectionIsDefault()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            tile.FindNeighbourTilePosition(default(Direction));
        }

        #endregion
    }
}
