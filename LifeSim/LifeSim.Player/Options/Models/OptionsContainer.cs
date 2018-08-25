using System.Collections.Generic;
using System.Linq;
using LifeSim.Player.Enums;
using LifeSim.Player.Options.Contracts;
using LifeSim.Player.Options.Models.Utilities;

namespace LifeSim.Player.Options.Models
{
    public class OptionsContainer : IOptionsContainer
    {
        private readonly Dictionary<string, OptionsTuple> options;

        public OptionsContainer()
        {
            options = new Dictionary<string, OptionsTuple>
            {
                {"1", new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.NewBorn, true, true, false)},

                {"2", new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.Baby, false, true, false)},
                {
                    "3",
                    new OptionsTuple("Go To Kindergarten (gotokindergarten)", "gotokindergarten", PlayerProgress.Baby,
                        true, false, false)
                },

                {"4", new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.Kid, false, true, false)},
                {
                    "5",
                    new OptionsTuple("Go To Primary School (gotoprimaryschool)", "gotoprimaryschool", PlayerProgress.Kid,
                        true, false, false)
                },
                {
                    "6",
                    new OptionsTuple("Take additional lessons (takelessons)", "takelessons", PlayerProgress.Kid, true,
                        false, false)
                },

                {"7", new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.Teen, false, true, false)},
                {
                    "8",
                    new OptionsTuple("Go To High School (gotohighschool)", "gotohighschool", PlayerProgress.Teen, true,
                        false, false)
                },
                {
                    "16",
                    new OptionsTuple("Take additional lessons (takelessons)", "takelessons", PlayerProgress.Teen, true,
                        false, false)
                },

                {
                    "9",
                    new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.HighSchoolGraduate, false, true, false)
                },
                {
                    "10",
                    new OptionsTuple("Go To University (gotouniversity)", "gotouniversity",
                        PlayerProgress.HighSchoolGraduate, true, false, false)
                },

                {"11", new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.Student, true, true, false)},

                {
                    "99",
                    new OptionsTuple("Job Names: SoftwareEngineer, PoliceOfficer, FireFighter, Scientist, Accountant",
                        "NotForUseJustInfo", PlayerProgress.NonEmployed, true, false, false)
                },
                {
                    "12",
                    new OptionsTuple("Apply for a Job (applyforjob jobName)", "applyforjob", PlayerProgress.NonEmployed,
                        true, true, false)
                },

                {"13", new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.Worker, true, true, false)},

                {"14", new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.CEO, true, true, false)},

                {"15", new OptionsTuple("Age Up (ageup)", "ageup", PlayerProgress.Retired, true, true, false)}
            };
        }

        public IEnumerable<string> CurrentStageOptions(PlayerProgress playerProgress, bool returnKey = false)
        {
            if (!returnKey)
            {
                var tempOptions = options
                    .Where(x => x.Value.PlayerProgress == playerProgress)
                    .Where(x => x.Value.IsUnlocked)
                    .Where(x => x.Value.CanBeUsedManyTimes || !x.Value.IsUsed);

                if (!tempOptions.Any())
                    return new List<string> { Exceptions.Models.Exceptions.NoCommandsAvailable };

                return tempOptions.Select(x => x.Value.CommandDisplay).ToList();
            }
            var temp = options
                .Where(x => x.Value.PlayerProgress == playerProgress)
                .Where(x => x.Value.IsUnlocked)
                .Where(x => x.Value.CanBeUsedManyTimes || !x.Value.IsUsed)
                .Select(option => option.Value.CommandKey).ToList();

            return temp;
        }

        public void ChangeCommandStatus(string commandKey, bool isUnlocked, bool canBeUsedManyTimes = false,
            bool isUsed = false)
        {
            // Bai Grozdan, Edo Challenge
            options.Where(x => x.Value.CommandKey == commandKey)
                .ToList()
                .ForEach(x =>
                {
                    x.Value.IsUnlocked = isUnlocked;
                    x.Value.CanBeUsedManyTimes = canBeUsedManyTimes;
                    x.Value.IsUsed = isUsed;
                });
        }

        public void UnlockAgeUpCommand(PlayerProgress playerProgress, bool isUnlocked = true,
            bool canBeUsedManyTimes = true, bool isUsed = false)
        {
            // Bai Grozdan, Edo Challenge
            options.Where(x => x.Value.CommandKey == "ageup")
                .Where(x => x.Value.PlayerProgress == playerProgress)
                .ToList()
                .ForEach(x =>
                {
                    x.Value.IsUnlocked = isUnlocked;
                    x.Value.CanBeUsedManyTimes = canBeUsedManyTimes;
                    x.Value.IsUsed = isUsed;
                });
        }
    }
}