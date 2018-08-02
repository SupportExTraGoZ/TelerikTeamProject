using System;
using System.Collections.Generic;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.PlayerOptions;

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
        
        public void PrintMenu(PlayerProgress playerProgress)
        {
            OptionsContainer options = new OptionsContainer();

            List<string> currOptinons = options.CurrentStageOptions(playerProgress);

            foreach (var elem  in currOptinons)
            {
                writer.WriteLine(elem);
            }
  
        }
        

        public void UserSelector()
        {
            throw new NotImplementedException();
        }
    }
}