using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Menu.Logo;
using System.Collections.Generic;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLines(List<string> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public void WriteLines(List<string> lines, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }

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