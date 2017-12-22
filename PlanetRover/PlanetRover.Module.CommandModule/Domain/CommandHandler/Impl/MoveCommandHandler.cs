using System;
using PlanetRover.Module.CommandModule.Domain.Command.Impl;
using PlanetRover.Module.Common.Domain;

namespace PlanetRover.Module.CommandModule.Domain.CommandHandler.Impl
{
    public class MoveCommandHandler : ICommandHandler<MoveCommand>
    {
        public void Handle(MoveCommand command, ICommandOwner owner)
        {
            if (owner is IMoveable)
            {
                if (command.Degree != 0) { throw new NotImplementedException(); }

                var tileOwner = ((ITileOwner)owner);
                var directionOwner = ((IDirectionOwner)owner);

                var targetPosition = tileOwner.CurrentTile.FindNeighbourTilePosition(directionOwner.Direction);

                tileOwner.Move(targetPosition);
            }
        }
    }
}