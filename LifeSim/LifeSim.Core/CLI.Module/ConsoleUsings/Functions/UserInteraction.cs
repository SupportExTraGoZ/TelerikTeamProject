using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Functions
{
    public class UserInteraction : IUserInteraction
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader consoleReader;


        public UserInteraction(IConsoleWriter writer, IConsoleReader consoleReader)
        {
            this.writer = writer;
            this.consoleReader = consoleReader;

        }

        public string AskUser(string message, bool sameLine)
        {
            if (!sameLine)
                this.writer.WriteLine(message);
            else
                this.writer.Write(message);
            var value = this.consoleReader.ReadLine();
            return value;

        }
    }
}
