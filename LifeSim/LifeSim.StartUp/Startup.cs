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
            //IReadable fileReader = new FileReader();
            //IDisplayable fileWriter = new OutputDisplayer();

            //IConsoleReader consoleReader = new ConsoleRead();
            //IConsoleWriter consoleWriter = new ConsoleWriter();

            //MenuLauncher menu = new MenuLauncher(consoleReader, consoleWriter, fileReader,fileWriter);
        }
    }
}