using LifeSim.Core.CLI.Module.ConsoleUsings;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
using LifeSim.Core.IO.Contracts;
using System;
using System.Collections.Generic;

namespace LifeSim.Core.Engine.Menu
{
    /// <summary>
    /// Still in dev
    /// </summary>
    public class MenuLauncher : IMenuLauncher
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;
        private readonly IReadable fileReader;

        public MenuLauncher(IConsoleWriter writer, IConsoleReader reader, IReadable fileReader)
        {
            //VALIDATE THIS
            this.writer = writer;
            this.reader = reader;
            this.fileReader = fileReader;
        }

        public void DisplayContent(string path)
        {
            var content = LoadDisplays(path);

            foreach (var line in content)
            {
                writer.WriteLine(line);
            }
        }

        public IList<string> LoadDisplays(string path)
        {
            var fileContent = fileReader.ReadFile(path);
            return fileContent;
        }

        public void UserSelector()
        {
            throw new NotImplementedException();
        }

     
    }
}