using System;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;

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