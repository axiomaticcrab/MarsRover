using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetRover.Configuration.Context;
using PlanetRover.Configuration.IoC.Factory;
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
        private readonly IModuleContext context;
        private readonly IDirectionManager directionManager;

        public RoverTest()
        {
            var containerFactory = new ContainerFactory();
            context = containerFactory.Resolve<IModuleContext>();
            directionManager = context.Resolve<IDirectionManager>();
        }

        #region Feature : Land

        [TestMethod]
        public void Should_LandAtOriginTile_When_NoSpesificPositionGiven()
        {
            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDirections().First(d => d.Code == "N");
            var rover = context.Resolve<Rover>();

            var roverLocation = rover.Land(planet, direction);

            Assert.AreEqual(planet.GetOriginTile().Position, roverLocation.Position);
            Assert.AreEqual(direction, roverLocation.Direction);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotLandToGivenTileBecauseTheTileIsNotExist))]
        public void Should_ThrowCannotLandToGivenTileBecauseTheTileIsNotExist_When_GivenTilePositionIsNotExist()
        {
            var planet = new Planet().With(10, 20, "TestPlanet");
            var location = new Location().With(new Position(-5, 3), directionManager.GetDirections().First(d => d.Code == "N"));
            var rover = context.Resolve<Rover>();

            rover.Land(planet, location);
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredParameterMissingException))]
        public void Should_ThrowRequiredParameterMissingException_When_MandotaryFieldsIsMissing()
        {
            context.Resolve<Rover>().Land(null, null, null);
        }

        #endregion
    }
}
