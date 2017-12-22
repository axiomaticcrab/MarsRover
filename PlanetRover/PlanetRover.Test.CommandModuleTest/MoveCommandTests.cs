using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetRover.Configuration.Context;
using PlanetRover.Configuration.IoC.Factory;
using PlanetRover.Module.CommandModule.Manager;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Manager;
using PlanetRover.Module.PlanetModule.Domain;
using PlanetRover.Module.RoverModule.Domain;
using PlanetRover.Module.RoverModule.Exception;

namespace PlanetRover.Test.CommandModuleTest
{
    [TestClass]
    public class MoveCommandTests
    {
        private readonly IModuleContext context;
        private readonly IDirectionManager directionManager;
        private readonly ICommandManager commandManager;

        public MoveCommandTests()
        {
            var factory = new ContainerFactory();
            context = factory.Resolve<IModuleContext>();
            directionManager = context.Resolve<IDirectionManager>();
            commandManager = context.Resolve<ICommandManager>();
        }

        #region Feature : Move

        [TestMethod]
        public void Should_MoveNorth_When_TargetTileIsExist()
        {
            int x = 5, y = 5;
            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDirections().First(d => d.Code == "N");
            var location = new Location().With(new Position(x, y), direction);
            var rover = context.Resolve<Rover>();
            rover.Land(planet, location);

            var expectedLocationAfterMove = new Location().With(new Position(x, y + 1), direction);
            var command = commandManager.GetCommands().First(c => c.Code == "M");

            commandManager.Apply(rover, command);

            
            Assert.AreEqual(expectedLocationAfterMove.Position, rover.Location.Position);
            Assert.AreEqual(expectedLocationAfterMove.Direction, rover.Location.Direction);
        }

        [TestMethod]
        [ExpectedException(typeof(CannotLandToGivenTileBecauseTheTileIsNotExist))]
        public void Should_ThrowCannotLandToGivenTileBecauseTheTileIsNotExistException_When_TargetTileIsNotExist()
        {

            var planet = new Planet().With(10, 20, "TestPlanet");
            var direction = directionManager.GetDirections().First(d => d.Code == "W");
            var rover = context.Resolve<Rover>();
            rover.Land(planet, direction);

            var command = commandManager.GetCommands().First(c => c.Code == "M");

            commandManager.Apply(rover, command);
        }

        #endregion
    }
}
