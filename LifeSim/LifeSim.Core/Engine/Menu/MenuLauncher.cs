using System;
using System.Collections.Generic;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using LifeSim.Player.Enums;

namespace LifeSim.Core.Engine.Menu
{
    /// <summary>
    ///     Still in dev
    /// </summary>
    public class MenuLauncher : IMenuLauncher
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;

        public MenuLauncher(IConsoleWriter writer, IConsoleReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }
        
        public void PrintMenu(PlayerProgress progress)
        {

        }
        

        public void UserSelector()
        {
            throw new NotImplementedException();
        }
    }
}