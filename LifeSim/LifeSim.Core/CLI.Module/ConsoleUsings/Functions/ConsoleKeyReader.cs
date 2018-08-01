using System;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Functions
{
    public class ConsoleKeyReader : IConsoleReadKey
    {
        public ConsoleKeyInfo ReadKey()
        {
            var cki = Console.ReadKey();

            return cki;
        }
    }
}