﻿using LifeSim.Player.Enums;
using LifeSim.Player.Options;
using LifeSim.Player.Options.Contracts;
using System.Collections.Generic;

namespace LifeSim.Core.Engine.Menu.Contracts
{
    public interface IMenuLauncher
    {
        void PrintMenu(PlayerProgress playerProgress, IOptionsContainer optionsContainer);
    }
}