﻿using System.Collections.Generic;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Contracts
{
    public interface IConsoleWriter
    {
        void WriteLines(List<string> lines);

        void WriteLines(List<string> lines, int count);

        void WriteLine(string line);

        void Write(string line);

        void PrintLogo();

        void SetCenterCursorPosition(string name);
    }
}