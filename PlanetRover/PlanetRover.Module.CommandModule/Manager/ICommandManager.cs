using PlanetRover.Module.CommandModule.Domain;
using PlanetRover.Module.CommandModule.Domain.Command;
using PlanetRover.Module.CommandModule.Domain.CommandHandler;

namespace PlanetRover.Module.CommandModule.Manager
{
    public interface ICommandManager
    {
        void Handle<C, H>(ICommandOwner<C, H> owner, C command) where C : ICommand
            where H : ICommandHandler<C>;
    }
}