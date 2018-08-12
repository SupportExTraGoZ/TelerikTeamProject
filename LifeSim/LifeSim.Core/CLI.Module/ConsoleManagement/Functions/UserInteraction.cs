using System.Collections.Generic;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions
{
    public class UserInteraction : IUserInteraction
    {
        private readonly IConsoleReader consoleReader;
        private readonly IConsoleWriter consoleWriter;
        private List<string> actionLog;

        public UserInteraction(IConsoleWriter writer, IConsoleReader consoleReader)
        {
            consoleWriter = writer;
            this.consoleReader = consoleReader;
            ActionLog = new List<string>();
        }

        public List<string> ActionLog
        {
            get => new List<string>(actionLog);
            set => actionLog = value;
        }

        public void AddAction(string action)
        {
            if (action != null)
                actionLog.Insert(0, action);
        }

        public string AskUser(string message, bool sameLine)
        {
            if (!sameLine)
                consoleWriter.WriteLine(message);
            else
                consoleWriter.Write(message);
            var value = consoleReader.ReadLine();
            return value;
        }
    }
}