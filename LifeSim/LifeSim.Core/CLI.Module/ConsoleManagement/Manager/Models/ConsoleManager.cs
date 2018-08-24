using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Models
{
    public class ConsoleManager : IConsoleManager
    {
        public ConsoleManager(IRenderer renderer, IConsoleCleaner cleaner, IUserInteraction userInteraction)
        {
            Renderer = renderer;
            Cleaner = cleaner;
            UserInteraction = userInteraction;
        }

        public IRenderer Renderer { get; }
        public IConsoleCleaner Cleaner { get; }
        public IUserInteraction UserInteraction { get; }
    }
}
