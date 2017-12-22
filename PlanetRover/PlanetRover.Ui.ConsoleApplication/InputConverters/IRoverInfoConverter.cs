namespace PlanetRover.Ui.ConsoleApplication.InputConverters
{
    interface IRoverInfoConverter : IInputConverter
    {
        IPositionConverter PositionConverter { get; }
        IDirectionConverter DirectionConverter { get; }
    }
}