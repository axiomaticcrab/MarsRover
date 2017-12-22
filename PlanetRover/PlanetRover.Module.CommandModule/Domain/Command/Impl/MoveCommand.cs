namespace PlanetRover.Module.CommandModule.Domain.Command.Impl
{
    public class MoveCommand : Command
    {
        public int Degree { get; set; }

        public MoveCommand(string code, int degree) : base(code)
        {
            Degree = degree;
        }
    }
}