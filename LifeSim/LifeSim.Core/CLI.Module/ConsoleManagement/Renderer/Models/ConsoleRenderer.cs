using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Models
{
    public class ConsoleRenderer : IConsoleRenderer
    {
        public ConsoleRenderer(IConsoleWriter writer, IConsoleReader reader)
        {
            Writer = writer;
            Reader = reader;
        }

        public IConsoleWriter Writer { get; }
        public IConsoleReader Reader { get; }
    }
}
