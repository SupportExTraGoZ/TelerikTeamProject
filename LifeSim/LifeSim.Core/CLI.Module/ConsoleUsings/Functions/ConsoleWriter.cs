using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using System;
using LifeSim.Core.Engine.Menu;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Functions
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public void PrintLogo(IMenuLauncher launcher, string path)
        {
            launcher.DisplayContent(path);
        }
    }
}
