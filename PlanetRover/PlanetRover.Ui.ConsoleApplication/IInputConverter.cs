namespace PlanetRover.Ui.ConsoleApplication
{
    interface IInputConverter
    {
        bool IsValid { get; }
        IInputConverter Convert(string input);
    }
}