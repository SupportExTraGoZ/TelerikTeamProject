using LifeSim.Core.CLI.Module.Contracts;
using LifeSim.Core.Contracts;
using LifeSim.Core.Contracts.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.WorkFunctions
{
    public class OutputDisplayer : IDisplayable
    {
        
        private IInputOutput writer;

        public OutputDisplayer()
        {
        }

        public OutputDisplayer(IInputOutput writer)
        {
            this.writer = writer;
        }

        public void DisplayLine(IList<string> content)
        {
            foreach (var line in content)
            {
                this.writer.Whrite(content);
            }
        }
    }
}