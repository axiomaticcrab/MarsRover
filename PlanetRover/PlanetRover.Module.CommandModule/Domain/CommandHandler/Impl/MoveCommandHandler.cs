using System;
using System.Linq;
using PlanetRover.Module.CommandModule.Domain.Command.Impl;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Manager;

namespace PlanetRover.Module.CommandModule.Domain.CommandHandler.Impl
{
    public class MoveCommandHandler : ICommandHandler<MoveCommand>
    {
        private readonly IDirectionManager directionManager;

        public MoveCommandHandler(IDirectionManager directionManager)
        {
            this.directionManager = directionManager;
        }

        public void Handle(MoveCommand command, ICommandOwner owner)
        {
            if (owner is IMoveable)
            {
                if (command.Degree != 0)
                {
                    throw new NotImplementedException();
                }

                var tileOwner = ((ITileOwner)owner);
                var directionOwner = ((IDirectionOwner)owner);

                var targetPosition = tileOwner.CurrentTile.FindNeighbourTilePosition(directionOwner.Direction);

                tileOwner.Move(targetPosition);
            }
        }
    }

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

                var newDirection = directionManager.GetDefaultDirections().First(x => x.Degree == newDegree);

                directionOwner.SetDirection(newDirection);
            }
        }
    }
}