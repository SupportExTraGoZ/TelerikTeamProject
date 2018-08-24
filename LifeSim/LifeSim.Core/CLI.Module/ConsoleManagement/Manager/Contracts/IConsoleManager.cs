using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts
{
    public interface IConsoleManager
    {
        IConsoleRenderer Renderer { get; }
        IConsoleCleaner Cleaner { get; }
        IUserInteraction UserInteraction { get; }
    }
}