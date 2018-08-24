using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Contracts;
using LifeSim.Player.Options.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Core.Engine.Menu.Manager.Models
{
    public class MenuManager : IMenuManager
    {
        public MenuManager(IMenuLauncher menuLauncher,IOptionsContainer optionsContainer)
        {
            MenuLauncher = menuLauncher;
            OptionsContainer = optionsContainer;
        }

        public IMenuLauncher MenuLauncher { get; }

        public IOptionsContainer OptionsContainer { get; }
    }
}
