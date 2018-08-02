using LifeSim.Player.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Player.PlayerOptions
{
    public class OptionsContainer
    {
        private static Dictionary<PlayerProgress, string> options;

        public OptionsContainer()
        {
            options = new Dictionary<PlayerProgress, string>();

            
            options.Add(PlayerProgress.NewBorn, "");
            options.Add(PlayerProgress.NewBorn, "");
            options.Add(PlayerProgress.NewBorn, "");

            options.Add(PlayerProgress.Baby, "");
            options.Add(PlayerProgress.Baby, "");
            options.Add(PlayerProgress.Baby, "");
            options.Add(PlayerProgress.Baby, "");

            //..
        }

        public List<string> CurrentStageOptions(PlayerProgress playerProgress)
        {
            List<string> stageOptions = new List<string>();

            foreach (var option in options)
            {
                if (option.Key.Equals(playerProgress))
                    stageOptions.Add(option.Value);
            }

            return stageOptions;
        }

    }
}
