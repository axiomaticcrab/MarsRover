using System;
using System.Linq;
using PlanetRover.Configuration.Context;
using PlanetRover.Module.CommandModule.Domain;
using PlanetRover.Module.CommandModule.Domain.Command;
using PlanetRover.Module.CommandModule.Domain.Command.Impl;
using PlanetRover.Module.CommandModule.Domain.CommandHandler;
using PlanetRover.Module.CommandModule.Domain.CommandHandler.Impl;
using PlanetRover.Module.CommandModule.Manager;
using PlanetRover.Module.Common.Domain;
using PlanetRover.Module.Common.Exception;
using PlanetRover.Module.Common.Manager;
using PlanetRover.Module.PlanetModule.Domain;
using PlanetRover.Module.PlanetModule.Exception;
using PlanetRover.Module.RoverModule.Exception;

namespace PlanetRover.Module.RoverModule.Domain
{
    public class Rover : IMoveable, IRotateable, ILocationOwner
    {
        #region IoC

        private readonly ICommandManager commandManager;
        private readonly IModuleContext context;

        public Rover(ICommandManager commandManager, IModuleContext context)
        {
            this.commandManager = commandManager;
            this.context = context;
        }

        #endregion

        public Location Location { get; protected set; }
        public Planet Planet { get; protected set; }

        public Location Land(Planet planet, Position position, Direction direction)
        {
            return Land(planet, new Location().With(position, direction));
        }

        public Location Land(Planet planet, Location location)
        {
            if (planet == null) { throw new RequiredParameterMissingException("planet"); }
            if (location == null) { throw new RequiredParameterMissingException("location"); }

            if (planet.HasTileAt(location.Position))
            {
                Location = location;
                Planet = planet;
                return Location;
            }
            throw new CannotLandToGivenTileBecauseTheTileIsNotExist(location.Position.ToString());
        }
        
        #region IMoveable Mappings

        MoveCommandHandler ICommandOwner<MoveCommand, MoveCommandHandler>.Handler
        {
            get { return context.Resolve<ICommandHandler<MoveCommand>>() as MoveCommandHandler; }
        }

        void ICommandOwner<MoveCommand, MoveCommandHandler>.Command(MoveCommand command)
        {
            commandManager.Handle<MoveCommand, MoveCommandHandler>(this, command);
        }

        #endregion

        #region IRotateable Mappings

        void ICommandOwner<RotationCommand, RotationCommandHandler>.Command(RotationCommand command)
        {
            commandManager.Handle<RotationCommand, RotationCommandHandler>(this, command);
        }

        RotationCommandHandler ICommandOwner<RotationCommand, RotationCommandHandler>.Handler
        {
            get { return context.Resolve<ICommandHandler<RotationCommand>>() as RotationCommandHandler; }
        }

        #endregion

        #region IDirectionOwner Mappings

        Direction IDirectionOwner.Direction
        {
            get { return Location.Direction; }
        }

        void IDirectionOwner.SetDirection(Direction direction)
        {
            Location.SetDirection(direction);
        }

        #endregion

        #region ITileOwner Mappings

        Tile ITileOwner.CurrentTile
        {
            get { return Planet.GetTileAt(Location.Position); }
        }

        void ITileOwner.Move(Position position)
        {
            try
            {
                var tile = Planet.GetTileAt(position);
                Location.SetPosition(tile.Position);
            }
            catch (PlanetHasNoTileAtGivenPosition)
            {
                throw new CannotLandToGivenTileBecauseTheTileIsNotExist(String.Format("Tile position : {0}",
                    position.ToString()));
            }

        }

        #endregion
        
        void ICommandOwner.Command(ICommand command)
        {
            if (command is MoveCommand)
            {
                ((IMoveable)this).Command((MoveCommand)command);
            }
            else if (command is RotationCommand)
            {
                ((IRotateable)this).Command((RotationCommand)command);
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Location.Position.X, Location.Position.Y, Location.Direction.Code);
        }
    }
}
