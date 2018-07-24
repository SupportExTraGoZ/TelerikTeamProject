using LifeSim.Core.CLI.Module.Contracts;
using LifeSim.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.WorkFunctions
{
    public class OutputDisplayer : IDisplayable
    {
        private IIOConsole writer;

        public OutputDisplayer()
        {
        }

        public OutputDisplayer(IIOConsole writer)
        {
            this.writer = writer;
        }

        public void DisplayLine(IList<string> content)
        {
            foreach (var line in content)
            {
                this.writer.WhriteOnConsole(content);
            }
        }
    }
}