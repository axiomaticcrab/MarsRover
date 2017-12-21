using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Exception;
using PlanetRover.Module.Common.Manager;

namespace PlanetRover.Test.CommonTest
{
    [TestClass]
    public class TileTests
    {
        private readonly IDirectionManager directionManager;

        public TileTests()
        {
            directionManager = new DirectionManager();
        }

        #region Feature : FindNeighbourTilePosition

        [TestMethod]
        public void Should_FindNeighbourTile_When_RequestedDirectionIsNorth()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            var neighbourTilePosition = tile.FindNeighbourTilePosition(directionManager.GetDefaultDirections().First(d => d.Code == "N"));

            Assert.AreEqual(y + 1, neighbourTilePosition.Y);
            Assert.AreEqual(x, neighbourTilePosition.X);
        }

        [TestMethod]
        public void Should_FindNeighbourTile_When_RequestedDirectionIsSouth()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            var neighbourTilePosition = tile.FindNeighbourTilePosition(directionManager.GetDefaultDirections().First(d => d.Code == "S"));

            Assert.AreEqual(y - 1, neighbourTilePosition.Y);
            Assert.AreEqual(x, neighbourTilePosition.X);
        }

        [TestMethod]
        public void Should_FindNeighbourTile_When_RequestedDirectionIsEast()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            var neighbourTilePosition = tile.FindNeighbourTilePosition(directionManager.GetDefaultDirections().First(d => d.Code == "E"));

            Assert.AreEqual(y, neighbourTilePosition.Y);
            Assert.AreEqual(x + 1, neighbourTilePosition.X);
        }

        [TestMethod]
        public void Should_FindNeighbourTile_When_RequestedDirectionIsWest()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            var neighbourTilePosition = tile.FindNeighbourTilePosition(directionManager.GetDefaultDirections().First(d => d.Code == "W"));

            Assert.AreEqual(y, neighbourTilePosition.Y);
            Assert.AreEqual(x - 1, neighbourTilePosition.X);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidParameterException))]
        public void Sould_ThrowInvalidParameterException_When_RequestedDirectionIsNull()
        {
            var x = 5;
            var y = 5;
            var tile = new Tile(x, y);

            tile.FindNeighbourTilePosition(default(Direction));
        }

        #endregion
    }
}
