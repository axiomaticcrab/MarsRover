namespace PlanetRover.Module.CommandModule.Domain.Command.Impl
{
    public class MoveCommand : Command
    {
        public float Degree { get; set; }

        public MoveCommand(string code, float degree) : base(code)
        {
            Degree = degree;
        }
    }
}