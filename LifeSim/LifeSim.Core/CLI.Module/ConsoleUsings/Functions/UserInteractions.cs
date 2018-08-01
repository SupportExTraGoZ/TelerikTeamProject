using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleUsings.Functions
{
    public class UserInteractions : IUserInteraction
    {
        private readonly IConsoleWriter writer;
        private readonly IConsoleReader consoleReader;
       

        public UserInteractions(IConsoleWriter writer, IConsoleReader consoleReader)
        {
            this.writer = writer;
            this.consoleReader = consoleReader;
          
        }

        public string AskUser(string message)
        {
            this.writer.WriteLine(message);
            var value = this.consoleReader.ReadLine();
            return value;
            
        }
    }
}
