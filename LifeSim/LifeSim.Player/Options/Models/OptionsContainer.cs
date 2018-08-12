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
                { "1", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.NewBorn, true, true, false) },

                { "2", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.Baby, false, true, false) },
                { "3", new CustomTuple("Go To Kindergarten (gotokindergarten)", "gotokindergarten", PlayerProgress.Baby, true, false, false) },

                { "4", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.Kid, false, true, false) },
                { "5", new CustomTuple("Go To Primary School (gotoprimaryschool)", "gotoprimaryschool", PlayerProgress.Kid, true, false, false) },
                { "6", new CustomTuple("Take additional lessons (takelessons)", "takelessons", PlayerProgress.Kid, true, false, false) },

                { "7", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.Teen, false, true, false) },
                { "8", new CustomTuple("Go To High School (gotohighschool)", "gotohighschool", PlayerProgress.Teen, true, false, false) },

                { "9", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.HighSchoolGraduate, false, true, false) },
                { "10", new CustomTuple("Go To University (gotouniversity)", "gotouniversity", PlayerProgress.HighSchoolGraduate, true, false, false) },

                { "11", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.Student, true, true, false) },

                { "99", new CustomTuple("Job Names: Software Engineer, Police Officer, Fire Fighter, Scientist, Accountant", "NotForUseJustInfo", PlayerProgress.NonEmployed, true, false, false) },
                { "12", new CustomTuple("Apply for a Job (applyforjob jobName)", "applyforjob", PlayerProgress.NonEmployed, true, true, false) },

                { "13", new CustomTuple("Age Up (ageup)", "ageup", PlayerProgress.Worker, true, true, false) }
            };
        }

        public IEnumerable<string> CurrentStageOptions(PlayerProgress playerProgress, bool returnKey = false)
        {
            if (!returnKey)
            {
                var tempOptions = options
                         .Where(x => x.Value.playerProgress == playerProgress)
                         .Where(x => x.Value.isUnlocked)
                         .Where(x => x.Value.canBeUsedManyTimes || !x.Value.isUsed);

                if (tempOptions.Count() == 0)
                    yield return "No commands available at this stage...";

                foreach (var option in tempOptions)
                {
                    yield return option.Value.commandDisplay;
                }
            }
            else
            {
                foreach (var option in options
                         .Where(x => x.Value.playerProgress == playerProgress)
                         .Where(x => x.Value.isUnlocked)
                         .Where(x => x.Value.canBeUsedManyTimes || !x.Value.isUsed))
                {
                    yield return option.Value.commandKey;
                }
            }
        }

        public void ChangeCommandStatus(string commandKey, bool isUnlocked, bool canBeUsedManyTimes = false, bool isUsed = false)
        {
            // Bai Grozdan, Edo Challenge
            this.options.Where(x => x.Value.commandKey == commandKey)
                .ToList()
                .ForEach(x =>
            {
                x.Value.isUnlocked = isUnlocked;
                x.Value.canBeUsedManyTimes = canBeUsedManyTimes;
                x.Value.isUsed = isUsed;
            });
        }

        public void UnlockAgeUpCommand(PlayerProgress playerProgress, bool isUnlocked = true, bool canBeUsedManyTimes = true, bool isUsed = false)
        {
            // Bai Grozdan, Edo Challenge
            this.options.Where(x => x.Value.commandKey == "ageup")
                .Where(x => x.Value.playerProgress == playerProgress)
                .ToList()
                .ForEach(x =>
            {
                x.Value.isUnlocked = isUnlocked;
                x.Value.canBeUsedManyTimes = canBeUsedManyTimes;
                x.Value.isUsed = isUsed;
            });
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