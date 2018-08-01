using System.Collections.Generic;

namespace LifeSim.Core.Engine.Menu
{
    public interface IMenuLauncher
    {
        void DisplayContent(string path);
        IList<string> LoadDisplays(string path);
        void UserSelector();
    }
}