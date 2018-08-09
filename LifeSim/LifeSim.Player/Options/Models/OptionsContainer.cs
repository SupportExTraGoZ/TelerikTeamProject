using LifeSim.Player.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using LifeSim.Player.Options.Contracts;
using System.Linq;

namespace LifeSim.Player.Options
{
    public class OptionsContainer : IOptionsContainer
    {
        private Dictionary<string, CustomTuple> options;

        public OptionsContainer()
        {
            options = new Dictionary<string, CustomTuple>
            {
                { "Age Up (ageup)", new CustomTuple(PlayerProgress.NewBorn, true, true, false) }
            };
        }

        public IEnumerable<string> CurrentStageOptions(PlayerProgress playerProgress)
        {
            foreach (var option in options
                     .Where(x => x.Value.playerProgress == playerProgress)
                     .Where(x => x.Value.isUnlocked)
                     .Where(x => x.Value.canBeUsedManyTimes || !x.Value.isUsed))
            {
                yield return option.Key;
            }
        }
    }

    class CustomTuple
    {
        internal PlayerProgress playerProgress;
        internal bool isUnlocked, canBeUsedManyTimes, isUsed;

        public CustomTuple(PlayerProgress playerProgress, bool isUnlocked, bool canBeUsedManyTimes, bool isUsed)
        {
            this.playerProgress = playerProgress;
            this.isUnlocked = isUnlocked;
            this.canBeUsedManyTimes = canBeUsedManyTimes;
            this.isUsed = isUsed;
        }
    }
}