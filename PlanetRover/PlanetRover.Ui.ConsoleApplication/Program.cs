using System;
using Castle.Windsor;
using PlanetRover.Configuration.IoC.Factory;
using PlanetRover.Ui.ConsoleApplication.InputConverters;
using PlanetRover.Ui.ConsoleApplication.InputConverters.Impl;

namespace PlanetRover.Ui.ConsoleApplication
{
    static class Program
    {
        private static ContainerFactory ContainerFactory;
        static Program()
        {
            ContainerFactory = new ContainerFactory();
            var windsorContainer = ContainerFactory.Get();
        }

        static void Main()
        {
            var planetSizeConverter = RequestData<DefaultPositionConverter>("Provide planet's top left corner position with whitespaces.");

            var firstRoverInfo = RequestData<DefaultRoverInfoConverter>("Provide first rover's information");
            var firstRoverCommands = RequestData<DefaultCommandConverter>("Provide commands for first rover");

            var secondRoverInfo = RequestData<DefaultRoverInfoConverter>("Provide second rover's information");
            var secondRoverCommands = RequestData<DefaultCommandConverter>("Provide commands for second rover");
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
