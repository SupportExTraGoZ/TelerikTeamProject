using LifeSim.Player.Enums;
using LifeSim.Player.Options.Contracts;

namespace LifeSim.Core.Engine.Menu.Contracts
{
    public interface IMenuLauncher
    {
        void PrintMenu(PlayerProgress playerProgress, IOptionsContainer optionsContainer);
    }
}