namespace PlanetRover.Module.CommandModule.Domain.Command
{
    public interface ICommand
    {
        string Code { get; }
    }

    public abstract class Command : ICommand
    {
        public string Code { get; protected set; }

        protected Command(string code)
        {
            Code = code;
        }
    }
}