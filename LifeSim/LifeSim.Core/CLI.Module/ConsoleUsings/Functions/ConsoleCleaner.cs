using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using System;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Functions
{
    public class ConsoleCleaner : IConsoleCleaner
    {
        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
