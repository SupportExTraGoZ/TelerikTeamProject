using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.IO.Contracts
{
    public interface IReadable
    {
        IList<string> ReadFile(string path);
    }
}