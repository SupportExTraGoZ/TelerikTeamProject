using LifeSim.Core.CLI.Module.ConsoleUsings;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
using System;


namespace LifeSim.Core.Engine.Menu
{
    /// <summary>
    /// Still in dev
    /// </summary>
    public class MenuLauncher
    {
        private readonly IConsoleUsageProvider writer = new ConsoleWriter();
        private readonly IConsoleUsageProvider reader = new ConsoleReader();

        public MenuLauncher(IConsoleUsageProvider writer, IConsoleUsageProvider reader)
        {
            //VALIDATE THIS
            this.writer = writer;
            this.reader = reader;
        }

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