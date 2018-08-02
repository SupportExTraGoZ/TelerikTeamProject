using System;
using System.Collections.Generic;
using LifeSim.Player.Enums;

namespace LifeSim.Player.Options.Contracts
{
    public interface IOptionsContainer
    {
        IEnumerable<string> CurrentStageOptions(PlayerProgress playerProgress);
    }
}
