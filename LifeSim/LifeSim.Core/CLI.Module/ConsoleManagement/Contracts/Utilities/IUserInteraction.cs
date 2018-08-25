using System.Collections.Generic;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Contracts.Utilities
{
    public interface IUserInteraction
    {
        List<string> ActionLog { get; set; }
        string AskUser(string message, bool sameLine);
        void AddAction(string action);
    }
}