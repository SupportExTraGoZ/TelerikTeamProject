using System.Collections.Generic;

namespace LifeSim.Core.Engine.Menu.Contracts
{
    /// <summary>
    /// Gives ability to display line of text (string) to the user.
    /// </summary>
    public interface IDisplayable
    {
        void DisplayLine(IList<string> content);
    }
}