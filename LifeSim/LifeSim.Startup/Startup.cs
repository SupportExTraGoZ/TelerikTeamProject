using LifeSim.Core.CLI.Module.Contracts;
using LifeSim.Core.CLI.Module.Modules;
using LifeSim.Core.Contracts;
using LifeSim.Core.Engine.Core;
using LifeSim.Core.Engine.Menu.Start.Menu;
using LifeSim.Core.WorkFunctions;
using LifeSim.Player.Models;
using System;

namespace LifeSim.Startup
{
    /// <summary>
    /// Console Client start point of "Life Simulator"
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("LifeSim is still under development!");

            // Working Player Creation - To be continued...
            //Player.Models.Player player = new Player.Models.Player("Danail", "Grozdanov", Player.Enums.GenderType.Male, Player.Enums.Birthplaces.Miami);

            //Stefan = Hire i'm testing menu ...
            var firstInstance = Engine.Instance;
            firstInstance.Start();
            //IReadable fileReader = new FileReader();
            //IDisplayable fileWriter = new OutputDisplayer();

            //IConsoleReader consoleReader = new ConsoleRead();
            //IConsoleWriter consoleWriter = new ConsoleWriter();

            //MenuLauncher menu = new MenuLauncher(consoleReader, consoleWriter, fileReader,fileWriter);
        }
    }
}