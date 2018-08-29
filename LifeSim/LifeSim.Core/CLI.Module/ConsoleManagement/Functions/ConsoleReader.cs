using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}