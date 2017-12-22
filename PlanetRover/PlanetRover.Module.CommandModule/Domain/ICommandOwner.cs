using PlanetRover.Module.CommandModule.Domain.Command;
using PlanetRover.Module.CommandModule.Domain.Command.Impl;
using PlanetRover.Module.CommandModule.Domain.CommandHandler;
using PlanetRover.Module.CommandModule.Domain.CommandHandler.Impl;
using PlanetRover.Module.Common.Domain;

namespace PlanetRover.Module.CommandModule.Domain
{
    public interface ICommandOwner<C,H> : ICommandOwner where C : ICommand where H : ICommandHandler<C>
    {
        void Command(C command);

        H Handler { get; }
    }

    public interface ICommandOwner
    {
        void Command(ICommand command);
    }

    public interface IMoveable : ICommandOwner<MoveCommand, MoveCommandHandler> , ITileOwner , IDirectionOwner
    {
        
    }

    public interface IRotateable : ICommandOwner<RotationCommand, RotationCommandHandler> , IDirectionOwner
    {
        
    }
}