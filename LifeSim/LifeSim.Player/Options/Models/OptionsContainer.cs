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
        private Dictionary<string, PlayerProgress> options;

        public OptionsContainer()
        {
            options = new Dictionary<string, PlayerProgress>
            {
                { "1. Age Up (ageup)", PlayerProgress.NewBorn }
            };
        }

        public IEnumerable<string> CurrentStageOptions(PlayerProgress playerProgress)
        {
            foreach (var option in options.Where(x => x.Value == playerProgress))
            {
                yield return option.Key;
            }
        }
    }
}
