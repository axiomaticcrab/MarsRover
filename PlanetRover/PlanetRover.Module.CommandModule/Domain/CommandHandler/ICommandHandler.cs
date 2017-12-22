using PlanetRover.Module.CommandModule.Domain.Command;
using PlanetRover.Module.Common.Domain;

namespace PlanetRover.Module.CommandModule.Domain.CommandHandler
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command, ICommandOwner commandOwner);
    }
}
