using System.Collections.Generic;

namespace LifeSim.Core.IO.Contracts
{
    public interface IReadable
    {
        IList<string> ReadFile(string path);
    }
}