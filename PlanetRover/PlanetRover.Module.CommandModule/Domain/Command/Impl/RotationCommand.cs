namespace PlanetRover.Module.CommandModule.Domain.Command.Impl
{
    public class RotationCommand : Command
    {
        public int Degree { get; protected set; }

        public RotationCommand(string code, int degree) : base(code)
        {
            Degree = degree;
        }
    }
}