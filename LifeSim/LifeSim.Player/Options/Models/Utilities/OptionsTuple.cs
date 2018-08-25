using LifeSim.Player.Enums;

namespace LifeSim.Player.Options.Models.Utilities
{
    internal class OptionsTuple
    {
        internal OptionsTuple(string commandDisplay, string commandKey, PlayerProgress playerProgress, bool isUnlocked,
                             bool canBeUsedManyTimes, bool isUsed)
        {
            this.CommandDisplay = commandDisplay;
            this.CommandKey = commandKey;
            this.PlayerProgress = playerProgress;
            this.IsUnlocked = isUnlocked;
            this.CanBeUsedManyTimes = canBeUsedManyTimes;
            this.IsUsed = isUsed;
        }

        internal string CommandDisplay { get; set; }
        internal string CommandKey { get; set; }
        internal bool IsUnlocked { get; set; }
        internal bool CanBeUsedManyTimes { get; set; }
        internal bool IsUsed { get; set; }
        internal PlayerProgress PlayerProgress { get; set; }
    }
}