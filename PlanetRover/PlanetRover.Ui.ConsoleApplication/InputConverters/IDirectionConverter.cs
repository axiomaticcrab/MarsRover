namespace PlanetRover.Ui.ConsoleApplication.InputConverters
{
    interface IDirectionConverter : IInputConverter
    {
        int Degree { get; }
    }
}