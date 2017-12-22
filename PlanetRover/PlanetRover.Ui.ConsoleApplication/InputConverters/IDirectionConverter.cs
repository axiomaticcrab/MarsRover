namespace PlanetRover.Ui.ConsoleApplication.InputConverters
{
    interface IDirectionConverter : IInputConverter
    {
        float Degree { get; }
    }
}