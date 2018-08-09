﻿using LifeSim.Player.Enums;
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
                { "1", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.NewBorn, true, true, false) },

                { "2", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.Baby, false, true, false) },
                { "3", new CustomTuple("Go To Kindergarten (gotokindergarten)", "gotokindergarten", PlayerProgress.Baby, true, false, false) }
            };
        }

        public IEnumerable<string> CurrentStageOptions(PlayerProgress playerProgress, bool returnKey = false)
        {
            if (!returnKey)
                foreach (var option in options
                         .Where(x => x.Value.playerProgress == playerProgress)
                         .Where(x => x.Value.isUnlocked)
                         .Where(x => x.Value.canBeUsedManyTimes || !x.Value.isUsed))
                {
                    yield return option.Value.commandDisplay;
                }
            else
                foreach (var option in options
                         .Where(x => x.Value.playerProgress == playerProgress)
                         .Where(x => x.Value.isUnlocked)
                         .Where(x => x.Value.canBeUsedManyTimes || !x.Value.isUsed))
                {
                    yield return option.Value.commandKey;
                }
        }

        public void ChangeCommandStatus(string commandKey, bool isUnlocked, bool canBeUsedManyTimes = false, bool isUsed = false)
        {
            var tempCommand = this.options.FirstOrDefault(x => x.Value.commandKey == commandKey);
            tempCommand.Value.isUnlocked = isUnlocked;
            tempCommand.Value.canBeUsedManyTimes = canBeUsedManyTimes;
            tempCommand.Value.isUsed = isUsed;
        }

        public void UnlockAgeUpCommand(PlayerProgress playerProgress, bool isUnlocked = true, bool canBeUsedManyTimes = true, bool isUsed = false)
        {
            var tempCommand = this.options.FirstOrDefault(x => x.Value.commandKey == "ageup" && x.Value.playerProgress == playerProgress);
            tempCommand.Value.isUnlocked = isUnlocked;
            tempCommand.Value.canBeUsedManyTimes = canBeUsedManyTimes;
            tempCommand.Value.isUsed = isUsed;
        }
    }

    class CustomTuple
    {
        internal string commandDisplay, commandKey;
        internal PlayerProgress playerProgress;
        internal bool isUnlocked, canBeUsedManyTimes, isUsed;

        public CustomTuple(string commandDisplay, string commandKey, PlayerProgress playerProgress, bool isUnlocked, bool canBeUsedManyTimes, bool isUsed)
        {
            this.commandDisplay = commandDisplay;
            this.commandKey = commandKey;
            this.playerProgress = playerProgress;
            this.isUnlocked = isUnlocked;
            this.canBeUsedManyTimes = canBeUsedManyTimes;
            this.isUsed = isUsed;
        }
    }
}