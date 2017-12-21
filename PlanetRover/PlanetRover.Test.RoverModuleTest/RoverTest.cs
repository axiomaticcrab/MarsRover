using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Exception;
using PlanetRover.Module.Common.Manager;
using PlanetRover.Module.PlanetModule.Domain;
using PlanetRover.Module.RoverModule.Domain;
using PlanetRover.Module.RoverModule.Exception;

namespace PlanetRover.Test.RoverModuleTest
{
    [TestClass]
    public class RoverTest
    {
        private readonly IDirectionManager directionManager;

        public RoverTest()
        {
            directionManager = new DirectionManager();
        }

        #region Feature : Land

        [TestMethod]
        public void Should_LandAtOriginTile_When_NoSpesificPositionGiven()
        {
            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDefaultDirections().First(d => d.Code == "N");
            var rover = new Rover();

            var roverLocation = rover.Land(planet, direction);

            Assert.AreEqual(planet.GetOriginTile().Position, roverLocation.Position);
            Assert.AreEqual(direction, roverLocation.Direction);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotLandToGivenTileBecauseTheTileIsNotExist))]
        public void Should_ThrowCannotLandToGivenTileBecauseTheTileIsNotExist_When_GivenTilePositionIsNotExist()
        {
            var planet = new Planet().With(10, 20, "TestPlanet");
            var location = new Location().With(new Position(-5, 3), directionManager.GetDefaultDirections().First(d => d.Code == "N"));
            var rover = new Rover();

            rover.Land(planet, location);
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredParameterMissingException))]
        public void Should_ThrowRequiredParameterMissingException_When_MandotaryFieldsIsMissing()
        {
            new Rover().Land(null, null, null);
        }

        #endregion

        #region Feature : Move

        [TestMethod]
        public void Should_MoveNorth_When_TargetTileIsExist()
        {
            int x = 5, y = 5;
            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDefaultDirections().First(d => d.Code == "N");
            var location = new Location().With(new Position(x, y), direction);
            var rover = new Rover();
            rover.Land(planet, location);

            var newLocationAfterMove = new Location().With(new Position(x, y + 1), direction);

            var roversNewLocation = rover.Move();

            Assert.AreEqual(newLocationAfterMove.Position, roversNewLocation.Position);
            Assert.AreEqual(newLocationAfterMove.Direction, roversNewLocation.Direction);
        }

        [TestMethod]
        public void Should_MoveSouth_When_TargetTileIsExist()
        {
            int x = 5, y = 5;
            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDefaultDirections().First(d => d.Code == "S");
            var location = new Location().With(new Position(x, y), direction);
            var rover = new Rover();
            rover.Land(planet, location);

            var newLocationAfterMove = new Location().With(new Position(x, y - 1), direction);

            var roversNewLocation = rover.Move();

            Assert.AreEqual(newLocationAfterMove.Position, roversNewLocation.Position);
            Assert.AreEqual(newLocationAfterMove.Direction, roversNewLocation.Direction);
        }

        [TestMethod]
        public void Should_MoveEast_When_TargetTileIsExist()
        {
            int x = 5, y = 5;
            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDefaultDirections().First(d => d.Code == "E");
            var location = new Location().With(new Position(x, y), direction);
            var rover = new Rover();
            rover.Land(planet, location);

            var newLocationAfterMove = new Location().With(new Position(x + 1, y), direction);

            var roversNewLocation = rover.Move();

            Assert.AreEqual(newLocationAfterMove.Position, roversNewLocation.Position);
            Assert.AreEqual(newLocationAfterMove.Direction, roversNewLocation.Direction);
        }

        [TestMethod]
        public void Should_MoveWest_When_TargetTileIsExist()
        {
            int x = 5, y = 5;
            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDefaultDirections().First(d => d.Code == "W");
            var location = new Location().With(new Position(x, y), direction);
            var rover = new Rover();
            rover.Land(planet, location);

            var newLocationAfterMove = new Location().With(new Position(x - 1, y), direction);

            var roversNewLocation = rover.Move();

            Assert.AreEqual(newLocationAfterMove.Position, roversNewLocation.Position);
            Assert.AreEqual(newLocationAfterMove.Direction, roversNewLocation.Direction);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotLandToGivenTileBecauseTheTileIsNotExist))]
        public void Should_ThrowCannotLandToGivenTileBecauseTheTileIsNotExist_When_TargetTileIsNotExist()
        {

            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDefaultDirections().First(d => d.Code == "W");
            var rover = new Rover();
            rover.Land(planet, direction);

            rover.Move();
        }

        #endregion
    }
}
