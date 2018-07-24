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

        private IConsoleReader consoleReader;
        private IConsoleWriter consoleDisplay;
        private IReadable fileReader;

        public MenuLauncher(IConsoleReader reader, IConsoleWriter display)
        {
            this.consoleReader = reader;
            this.consoleDisplay = display;
            
        }

        public void DisplayContent(string path)
        {
            this.consoleDisplay.WhriteOnConsole(this.fileReader.ReadFile(path));
        }
    }
}