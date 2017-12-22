using System.Collections.Generic;
using PlanetRover.Module.CommandModule.Domain;
using PlanetRover.Module.CommandModule.Domain.Command;
using PlanetRover.Module.CommandModule.Domain.Command.Impl;
using PlanetRover.Module.CommandModule.Domain.CommandHandler;

namespace PlanetRover.Module.CommandModule.Manager
{
    public class CommandManager : ICommandManager
    {
        static List<Command> defaultCommands = new List<Command>
        {
            new RotationCommand("L",90),
            new RotationCommand("R",90),
            new MoveCommand("M",0)
        };


        public void Handle<C, H>(ICommandOwner<C, H> owner, C command) where C : ICommand where H : ICommandHandler<C>
        {
            owner.Handler.Handle(command, owner);
        }
    }
}
