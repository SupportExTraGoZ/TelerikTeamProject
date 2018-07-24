using LifeSim.Core.CLI.Module.Contracts;
using LifeSim.Core.Contracts;
using LifeSim.Core.Contracts.IO;
using LifeSim.Core.WorkFunctions.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.Engine.Menu.Start.Menu
{
    public class MenuLauncher
    {
        // private IList<string> logo;

        private IConsoleReader reader;
        private IConsoleWriter display;
        private IReadable fileReader;

        public MenuLauncher(IConsoleReader reader, IConsoleWriter display)
        {
            this.reader = reader;
            this.display = display;
            //this.fileReader = new FileReader();
        }

        public void DisplayContent(string path)
        {
            this.display.WhriteOnConsole(this.fileReader.ReadFile(path));
        }
    }
}