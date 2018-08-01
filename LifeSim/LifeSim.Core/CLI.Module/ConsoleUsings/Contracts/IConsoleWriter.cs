using System;
using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Menu;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Contracts
{
    public interface IConsoleWriter
    {
        void WriteLine(string line);
        
        void PrintLogo(IMenuLauncher launcher, string path);
    }
}
