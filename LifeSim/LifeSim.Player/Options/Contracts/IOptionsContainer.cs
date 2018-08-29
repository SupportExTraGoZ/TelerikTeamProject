using System.Collections.Generic;
using LifeSim.Player.Enums;

namespace LifeSim.Player.Options.Contracts
{
    public interface IOptionsContainer
    {
        IEnumerable<string> CurrentStageOptions(PlayerProgress playerProgress, bool returnKey);

        void ChangeCommandStatus(string commandKey, bool isUnlocked, bool canBeUsedManyTimes = false,
            bool isUsed = false);

        void UnlockAgeUpCommand(PlayerProgress playerProgress, bool isUnlocked = true, bool canBeUsedManyTimes = true,
            bool isUsed = false);
    }
}