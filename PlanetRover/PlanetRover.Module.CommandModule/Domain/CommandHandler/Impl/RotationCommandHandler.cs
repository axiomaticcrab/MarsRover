using System.Linq;
using PlanetRover.Module.CommandModule.Domain.Command.Impl;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Manager;

namespace PlanetRover.Module.CommandModule.Domain.CommandHandler.Impl
{
    public class RotationCommandHandler : ICommandHandler<RotationCommand>
    {
        private readonly IDirectionManager directionManager;

        public RotationCommandHandler(IDirectionManager directionManager)
        {
            this.directionManager = directionManager;
        }

        public void Handle(RotationCommand command, ICommandOwner commandOwner)
        {
            if (commandOwner is IRotateable)
            {
                var directionOwner = ((IDirectionOwner)commandOwner);

                var newDegree = directionOwner.Direction.Degree.Add(command.Degree);

                var newDirection = directionManager.GetDirections().First(x => x.Degree == newDegree);

                directionOwner.SetDirection(newDirection);
            }
        }
    }
}