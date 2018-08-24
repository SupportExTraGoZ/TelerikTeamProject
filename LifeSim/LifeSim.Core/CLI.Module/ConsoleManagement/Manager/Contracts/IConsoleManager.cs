using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts
{
    public interface IConsoleManager 
    {
        IRenderer Renderer { get; }
        IConsoleCleaner Cleaner { get; }
        IUserInteraction UserInteraction { get; }
    }
}
