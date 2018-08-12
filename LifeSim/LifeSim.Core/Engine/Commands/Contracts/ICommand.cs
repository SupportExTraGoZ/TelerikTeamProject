using System.Collections.Generic;

namespace LifeSim.Core.Engine.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}