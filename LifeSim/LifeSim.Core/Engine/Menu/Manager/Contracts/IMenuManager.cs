using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Player.Options.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.Engine.Menu.Manager.Contracts
{
    public interface IMenuManager
    {
        IMenuLauncher MenuLauncher { get; }
        
        IOptionsContainer OptionsContainer { get; }
    }
}
