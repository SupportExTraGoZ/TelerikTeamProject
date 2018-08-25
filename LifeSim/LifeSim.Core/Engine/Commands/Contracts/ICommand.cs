using System.Collections.Generic;

namespace LifeSim.Core.Engine.Commands.Contracts
{
    public interface ICommand
    {
        string Name { get; set; }

        IList<string> Parameters { get; set; }

        string Execute();
    }
}