namespace PlanetRover.Ui.ConsoleApplication
{
    interface IPositionConverter : IInputConverter
    {
        int X { get; }
        int Y { get; }
    }
}