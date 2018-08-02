using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Menu.Logo;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void Write(string line)
        {
            Console.Write(line);
        }

        public void PrintLogo()
        {
            Console.WriteLine(Logo.GetLogo());
        }

        public void SetCenterCursorPosition(string name)
        {
            Console.SetCursorPosition((Console.WindowWidth - name.Length) / 2, Console.CursorTop);
        }
    }
}