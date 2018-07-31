using LifeSim.Core.CLI.Module.Contracts;
using LifeSim.Core.CLI.Module.Modules;
using LifeSim.Core.Contracts;
using LifeSim.Core.Engine.Menu.Start.Menu;
using LifeSim.Core.WorkFunctions;
using LifeSim.Player;
using System;

namespace LifeSim.StartUp
{
    /// <summary>
    /// Console Client start point of "Life Simulator"
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("LifeSim is still under development!");

            Player.Player player = new Player.Player();

            //Stefan = Hire i'm testing menu ... 
            //IReadable fileReader = new FileReader();
            //IDisplayable fileWriter = new OutputDisplayer();

            //IConsoleReader consoleReader = new ConsoleRead();
            //IConsoleWriter consoleWriter = new ConsoleWriter();

            //MenuLauncher menu = new MenuLauncher(consoleReader, consoleWriter, fileReader,fileWriter);
        }
    }
}