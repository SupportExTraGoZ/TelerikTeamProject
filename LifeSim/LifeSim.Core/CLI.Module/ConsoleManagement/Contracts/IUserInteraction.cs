using System.Collections.Generic;
namespace LifeSim.Core.CLI.Module.ConsoleManagement.Contracts
{
    public interface IUserInteraction
    {
        string AskUser(string message, bool sameLine);
        List<string> ActionLog { get; set; }
    }
}