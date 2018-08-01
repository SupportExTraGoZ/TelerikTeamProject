using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Functions
{
    public class UserInteraction : IUserInteraction
    {
        private readonly IConsoleReader consoleReader;
        private readonly IConsoleWriter writer;

        public UserInteraction(IConsoleWriter writer, IConsoleReader consoleReader)
        {
            this.writer = writer;
            this.consoleReader = consoleReader;
        }

        public string AskUser(string message, bool sameLine)
        {
            if (!sameLine)
                writer.WriteLine(message);
            else
                writer.Write(message);
            var value = consoleReader.ReadLine();
            return value;
        }
    }
}