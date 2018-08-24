using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Models
{
    public class ConsoleManager : IConsoleManager
    {
        public ConsoleManager(IConsoleRenderer renderer, IConsoleCleaner cleaner, IUserInteraction userInteraction)
        {
            Renderer = renderer;
            Cleaner = cleaner;
            UserInteraction = userInteraction;
        }

        public IConsoleRenderer Renderer { get; }
        public IConsoleCleaner Cleaner { get; }
        public IUserInteraction UserInteraction { get; }
    }
}