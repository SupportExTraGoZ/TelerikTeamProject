using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using System;


namespace LifeSim.Core.CLI.Module.ConsoleUsings.Functions
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
