using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Contracts
{
    public interface IConsoleWriter : IConsoleUsageProvider
    {
        void WriteLine(string line);
    }
}
