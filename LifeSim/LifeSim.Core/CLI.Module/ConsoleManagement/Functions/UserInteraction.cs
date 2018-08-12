using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using System.Collections.Generic;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions
{
    public class UserInteraction : IUserInteraction
    {
        private readonly IConsoleReader consoleReader;
        private readonly IConsoleWriter consoleWriter;
        private List<string> actionLog;

        public List<string> ActionLog
        {
            get
            {
                return new List<string>(actionLog);
            }
            set
            {
                this.actionLog = value;
            }
        }

        public void AddAction(string action)
        {
            if (action != null)
                this.actionLog.Add(action);
        }

        public UserInteraction(IConsoleWriter writer, IConsoleReader consoleReader)
        {
            this.consoleWriter = writer;
            this.consoleReader = consoleReader;
            this.ActionLog = new List<string>();
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