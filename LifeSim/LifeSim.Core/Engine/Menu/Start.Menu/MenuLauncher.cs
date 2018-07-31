using LifeSim.Core.CLI.Module.Contracts;
using LifeSim.Core.Contracts;
using LifeSim.Core.Contracts.IO;
using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Core.CLI.Module.Modules;
using LifeSim.Core.WorkFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.Engine.Menu.Start.Menu
{
    /// <summary>
    /// Still in dev
    /// </summary>
    public class MenuLauncher : IMenuLauncher
    {
        IInputOutput fileReader;
        IInputOutput displayer;
        IInputOutput reader;
        //IConsoleReader consoleReader;
        //IConsoleWriter consoleDisplay;

        //private IReadable fileReader;
        //private IDisplayable fileDisplayer;

        //public MenuLauncher(IConsoleReader reader, IConsoleWriter display, 
        //    IReadable fileReader, IDisplayable fileDisplayer)
        //{
        //    this.consoleReader = reader;
        //    this.consoleDisplay = display;
        //    this.fileReader = fileReader;
        //    this.fileDisplayer = fileDisplayer;
        //}

        //public void DisplayContent(string path)
        //{
        //    this.consoleDisplay.Whrite(this.fileReader.ReadFile(path));
        //}
        public void DisplayContent(string path)
        {
            throw new NotImplementedException();
        }

        public void LoadDisplays(string path)
        {
            throw new NotImplementedException();
        }

        public void UserSelector()
        {
            throw new NotImplementedException();
        }
    }
}