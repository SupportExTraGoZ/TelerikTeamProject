using System;
using System.Collections.Generic;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using LifeSim.Core.IO.Contracts;

namespace LifeSim.Core.Engine.Menu
{
    /// <summary>
    ///     Still in dev
    /// </summary>
    public class MenuLauncher : IMenuLauncher
    {
        private readonly IReadable fileReader;
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;

        public MenuLauncher(IConsoleWriter writer, IConsoleReader reader, IReadable fileReader)
        {
            this.writer = writer;
            this.reader = reader;
            this.fileReader = fileReader;
        }

        public void DisplayContent(string path)
        {
            var content = LoadDisplays(path);

            foreach (var line in content)
                writer.WriteLine(line);
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