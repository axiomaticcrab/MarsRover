namespace PlanetRover.Ui.ConsoleApplication.InputConverters
{
    interface IInputConverter
    {
        bool IsValid { get; }
        IInputConverter Convert(string input);
    }
}