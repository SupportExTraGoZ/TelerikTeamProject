using System.Collections.Generic;

namespace LifeSim.Core.Engine.Commands.Contracts
{
    public interface ICommandParser
    {
        ICommand GetCommand(string fullCommand);

        bool ProcessCommand(string commandAsString);

        void ForceCommand(string commandAsString);

        IList<string> ParseParameters(string fullCommand);
    }
}