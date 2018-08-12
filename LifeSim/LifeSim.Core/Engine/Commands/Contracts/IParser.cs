using System.Collections.Generic;

namespace LifeSim.Core.Engine.Commands.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}