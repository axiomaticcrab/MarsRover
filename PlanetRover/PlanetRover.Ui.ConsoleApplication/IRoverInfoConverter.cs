namespace PlanetRover.Ui.ConsoleApplication
{
    interface IRoverInfoConverter : IInputConverter
    {
        IPositionConverter PositionConverter { get; }
        IDirectionConverter DirectionConverter { get; }
    }
}