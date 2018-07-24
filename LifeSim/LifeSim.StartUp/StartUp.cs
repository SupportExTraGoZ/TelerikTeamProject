﻿using LifeSim.Core.CLI.Module.Contracts;
using LifeSim.Core.CLI.Module.Modules;
using LifeSim.Core.Contracts;
using LifeSim.Core.Engine.Menu.Start.Menu;
using LifeSim.Core.WorkFunctions;
using System;

namespace LifeSim.StartUp
{
    /// <summary>
    /// Console Client start point of "Life Simulator"
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("LifeSim is still under development!");

            //Stefan = Hire i'm testing menu ... 
            IReadable fileReader = new FileReader();
            IDisplayable fileWriter = new OutputDisplayer();

            IConsoleReader consoleReader = new ConsoleRead();
            IConsoleWriter consoleWriter = new ConsoleWriter();

            //MenuLauncher menu = new MenuLauncher(consoleWriter, consoleReader,fileReader,fileWriter);
        }
    }
}