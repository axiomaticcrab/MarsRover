namespace PlanetRover.Ui.ConsoleApplication.InputConverters
{
    interface IPositionConverter : IInputConverter
    {
        int X { get; }
        int Y { get; }
    }
}