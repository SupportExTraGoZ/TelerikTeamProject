using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions
{
    public class ConsoleCleaner : IConsoleCleaner
    {
        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}