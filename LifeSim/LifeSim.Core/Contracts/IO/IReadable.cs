using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.Contracts
{
    public interface IReadable
    {
        IList<string> ReadFile(string path);
    }
}