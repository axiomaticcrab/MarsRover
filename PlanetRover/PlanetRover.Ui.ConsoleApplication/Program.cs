using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetRover.Ui.ConsoleApplication
{
    static class Program
    {
        static void Main()
        {
            var planetSizeConverter = RequestData<DefaultPositionConverter>("Provide planet's top left corner position with whitespaces.");
            var firstRoverInfo = RequestData<DefaultRoverInfoConverter>("Provide first rover's information");
            var secondRoverInfo = RequestData<DefaultRoverInfoConverter>("Provide second rover's information");
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
