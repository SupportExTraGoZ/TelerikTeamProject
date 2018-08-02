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
                { "1. Age Up", PlayerProgress.NewBorn },
                { "2. Test+", PlayerProgress.NewBorn },
                { "3. TestPlus", PlayerProgress.NewBorn },
                { "4. TestMinus", PlayerProgress.NewBorn }
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
