using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.CLI.Module.Contracts
{
    public interface IConsoleWriter
    {
        void WhriteOnConsole(IList<string> line);
    }
}