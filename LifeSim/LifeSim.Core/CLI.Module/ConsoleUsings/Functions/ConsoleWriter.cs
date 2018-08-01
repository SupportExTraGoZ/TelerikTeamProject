using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using System;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Functions
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
