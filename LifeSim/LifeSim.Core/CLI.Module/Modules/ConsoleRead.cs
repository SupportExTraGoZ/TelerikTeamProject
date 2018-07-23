using LifeSim.Core.CLI.Module.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.CLI.Module.Modules
{
    public class ConsoleRead : IConsoleReader
    {
        public string ReadFromConsole()
        {
            return Console.ReadLine();
        }
    }
}