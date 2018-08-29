using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Player.Options.Contracts;

namespace LifeSim.Core.Engine.Menu.Manager.Contracts
{
    public interface IMenuManager
    {
        IMenuLauncher MenuLauncher { get; }

        IOptionsContainer OptionsContainer { get; }
    }
}