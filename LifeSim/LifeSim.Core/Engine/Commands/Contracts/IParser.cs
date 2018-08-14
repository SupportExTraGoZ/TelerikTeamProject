using System.Collections.Generic;

namespace LifeSim.Core.Engine.Commands.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        bool ProcessCommand(string commandAsString);

        IList<string> ParseParameters(string fullCommand);
    }
}