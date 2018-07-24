using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.Contracts
{
    /// <summary>
    /// Gives ability to display line of text (string) to the user.
    /// </summary>
    public interface IDisplayable
    {
        void DisplayLine(IList<string> content);
    }
}