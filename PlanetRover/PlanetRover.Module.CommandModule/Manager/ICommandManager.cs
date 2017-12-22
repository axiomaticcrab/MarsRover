using System.Collections.Generic;
using PlanetRover.Module.CommandModule.Domain;
using PlanetRover.Module.CommandModule.Domain.Command;
using PlanetRover.Module.CommandModule.Domain.Command.Impl;
using PlanetRover.Module.CommandModule.Domain.CommandHandler;

namespace PlanetRover.Module.CommandModule.Manager
{
    public interface ICommandManager
    {
        void Handle<C, H>(ICommandOwner<C, H> owner, C command) where C : ICommand
            where H : ICommandHandler<C>;

        List<Command> GetCommands();

        void Apply(ICommandOwner owner, ICommand command);
    }

    public class CommandManager : ICommandManager
    {
        public void Handle<C, H>(ICommandOwner<C, H> owner, C command) where C : ICommand where H : ICommandHandler<C>
        {
            owner.Handler.Handle(command, owner);
        }

        public List<Command> GetCommands()
        {
            return new List<Command>
                {
                    new RotationCommand("L", 90),
                    new RotationCommand("R", -90),
                    new MoveCommand("M", 0)
                };
        }

        public void Apply(ICommandOwner owner, ICommand command)
        {
            owner.Command(command);
        }
    }
}