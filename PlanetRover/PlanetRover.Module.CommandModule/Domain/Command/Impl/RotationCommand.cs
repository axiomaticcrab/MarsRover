namespace PlanetRover.Module.CommandModule.Domain.Command.Impl
{
    public class RotationCommand : Command
    {
        public float Degree { get; protected set; }

        public RotationCommand(string code, float degree) : base(code)
        {
            Degree = degree;
        }
    }
}