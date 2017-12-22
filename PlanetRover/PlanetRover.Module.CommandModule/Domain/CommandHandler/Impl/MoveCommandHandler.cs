using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using PlanetRover.Module.CommandModule.Domain.Command;
using PlanetRover.Module.CommandModule.Domain.Command.Impl;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Manager;

namespace PlanetRover.Module.CommandModule.Domain.CommandHandler.Impl
{
    public class MoveCommandHandler : ICommandHandler<MoveCommand>
    {
        public void Handle(MoveCommand command, ICommandOwner owner)
        {
            if (owner is IPositionOwner)
            {
                if (command.Degree != 0)
                {
                    throw new NotImplementedException();
                }

                var positionOwner = ((IPositionOwner)owner);
                positionOwner.SetPosition(new Position(positionOwner.Position.X, positionOwner.Position.Y + 1));
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
            if (commandOwner is IDirectionOwner)
            {
                var directionOwner = ((IDirectionOwner)commandOwner);

                var newDegree = directionOwner.Direction.DegreeInRadian + (command.Degree);

                var newDirection =
                directionManager.GetDefaultDirections().First(x => x.DegreeInRadian == newDegree);

                directionOwner.SetDirection(newDirection);
            }
        }
    }
}