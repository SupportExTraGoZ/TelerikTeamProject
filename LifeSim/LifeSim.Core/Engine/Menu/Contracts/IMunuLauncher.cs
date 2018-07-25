using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.Engine.Menu.Contracts
{
    public interface IMunuLauncher
    {
        void DisplayContent(string path);

        void LoadDisplays(string path);

        void UserSelector();


    }
}
