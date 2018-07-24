using LifeSim.Core.CLI.Module.Contracts;
using LifeSim.Core.Contracts;
using LifeSim.Core.WorkFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.Engine.Menu.Start.Menu
{
    /// <summary>
    /// Still in dev
    /// </summary>
    public class MenuLauncher
    {
        // private IList<string> logo;

        private IIOConsole consoleReader;
        private IIOConsole consoleDisplay;

        private IReadable fileReader;
        private IDisplayable fileDisplayer;

        public MenuLauncher(IIOConsole reader, IIOConsole display, 
            IReadable fileReader, IDisplayable fileDisplayer)
        {
            this.consoleReader = reader;
            this.consoleDisplay = display;
            this.fileReader = fileReader;
            this.fileDisplayer = fileDisplayer;
        }

        public void DisplayContent(string path)
        {
            this.consoleDisplay.Whrite(this.fileReader.ReadFile(path));
        }
    }
}