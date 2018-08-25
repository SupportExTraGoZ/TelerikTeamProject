using System.Collections.Generic;

namespace LifeSim.Core.Engine.Commands.Contracts
{
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters(string commandParameters);

        string Execute(IList<string> parameters);
    }
}