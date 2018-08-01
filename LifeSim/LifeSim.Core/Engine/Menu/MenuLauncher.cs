using LifeSim.Core.CLI.Module.ConsoleUsings;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
using LifeSim.Core.IO.Contracts;
using System;


namespace LifeSim.Core.Engine.Menu
{
    /// <summary>
    /// Still in dev
    /// </summary>
    public class MenuLauncher : IMenuLauncher
    {
        private readonly IConsoleUsageProvider writer;
        private readonly IConsoleUsageProvider reader;
        private readonly IReadable fileReader;

        public MenuLauncher(IConsoleUsageProvider writer, IConsoleUsageProvider reader, IReadable fileReader)
        {
            //VALIDATE THIS
            this.writer = writer;
            this.reader = reader;
            this.fileReader = fileReader;
        }

        public void DisplayContent(string path)
        {
           
        }

        public void LoadDisplays(string path)
        {
            var fileContent = fileReader.ReadFile(path);
            

        }

        public void UserSelector()
        {
            throw new NotImplementedException();
        }
    }
}