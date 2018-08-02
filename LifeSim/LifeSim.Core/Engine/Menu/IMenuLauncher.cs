using LifeSim.Player.Enums;
using System.Collections.Generic;

namespace LifeSim.Core.Engine.Menu
{
    public interface IMenuLauncher
    {
        void PrintMenu(PlayerProgress playerProgress);
        void UserSelector();
    }
}