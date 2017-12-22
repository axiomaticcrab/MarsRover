using System;
using System.Linq;
using Castle.Windsor;
using PlanetRover.Configuration.IoC.Factory;
using PlanetRover.Module.CommandModule.Manager;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Manager;
using PlanetRover.Module.PlanetModule.Domain;
using PlanetRover.Module.PlanetModule.Manager;
using PlanetRover.Module.RoverModule.Domain;
using PlanetRover.Module.RoverModule.Manager;
using PlanetRover.Ui.ConsoleApplication.InputConverters;
using PlanetRover.Ui.ConsoleApplication.InputConverters.Impl;

namespace PlanetRover.Ui.ConsoleApplication
{
    static class Program
    {
        private static readonly ContainerFactory ContainerFactory;
        private static readonly IWindsorContainer Container;
        private static readonly IPlanetManager PlanetManager;
        private static readonly IRoverManager RoverManager;
        private static readonly IDirectionManager DirectionManager;
        private static readonly ICommandManager CommandManager;

        static Program()
        {
            ContainerFactory = new ContainerFactory();
            Container = ContainerFactory.Get();
            PlanetManager = Container.Resolve<IPlanetManager>();
            RoverManager = Container.Resolve<IRoverManager>();
            DirectionManager = ContainerFactory.Resolve<IDirectionManager>();
            CommandManager = ContainerFactory.Resolve<ICommandManager>();
        }

        static void Main()
        {


            var planetSizeConverter = RequestData<DefaultPositionConverter>("Provide planet's top left corner position with whitespaces.");
            var planet = PlanetManager.CreatePlanet(planetSizeConverter.X, planetSizeConverter.Y, "Mars");

            var firstRoverInfo = RequestData<DefaultRoverInfoConverter>("Provide first rover's information");
            var firstRover = CreateRover(firstRoverInfo, planet);
            var firstRoverCommands = RequestData<DefaultCommandConverter>("Provide commands for first rover");

            var secondRoverInfo = RequestData<DefaultRoverInfoConverter>("Provide second rover's information");
            var secondRover = CreateRover(secondRoverInfo, planet);
            var secondRoverCommands = RequestData<DefaultCommandConverter>("Provide commands for second rover");

            CommandRover(firstRover, firstRoverCommands);
            Console.WriteLine(firstRover.ToString());

            //CommandRover(secondRover, secondRoverCommands);
            //Console.WriteLine(secondRover.ToString());

            Console.WriteLine("Done !");
            Console.ReadLine();
        }

        static void CommandRover(Rover rover, ICommandConverter commandConverter)
        {
            commandConverter.Commands.ForEach(cc =>
            {
                var command = CommandManager.GetCommands().First(c => c.Code == cc);
                CommandManager.Handle(rover, command);
            });
        }

        static Rover CreateRover(IRoverInfoConverter roverInfoConverter, Planet planet)
        {
            var position = new Position(roverInfoConverter.PositionConverter.X, roverInfoConverter.PositionConverter.Y);
            var direction =
                DirectionManager.GetDefaultDirections()
                    .First(x => x.Degree == roverInfoConverter.DirectionConverter.Degree);
            var location = new Location().With(position, direction);
            return RoverManager.CreateRoverAndLand(planet, location);
        }

        static T RequestData<T>(string requestMessage) where T : IInputConverter, new()
        {
            var converter = new T();

            while (converter.IsValid == false)
            {
                Console.WriteLine(requestMessage);
                var input = Console.ReadLine();
                converter.Convert(input);
            }
            return converter;
        }
    }
}
