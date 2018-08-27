using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Player.Enums;

namespace LifeSim.Core.Engine.Commands.Actions.General
{
    public class AgeUpCommand : ICommand
    {
        private readonly IEngine engine;

        public AgeUpCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Name { get; set; }

        public IList<string> Parameters { get; set; }

        public string Execute()
        {
            // Increase the player's Age & his parent's Age.
            var player = engine.Player;
            if (!player.IsDead)
                player.Age++;
            if (!player.Father.IsDead)
                player.Father.Age++;
            if (!player.Mother.IsDead)
                player.Mother.Age++;

            // Update GameTime Year
            engine.GameTime = engine.GameTime.AddYears(1);

            // Give the player money, as of parents gifts and etc. during the year...
            player.Money += 250;

            if (player.HasJob)
            {
                if (player.Age <= 30)
                    player.Job.MonthlySalary += 500;
                else
                    player.Job.MonthlySalary += 250;
                player.Money += player.Job.MonthlySalary * 12;
            }

            if (!player.Father.IsDead && player.Father.Age > 65)
            {
                var deathChance = engine.Generator.NumberGenerator.RandomChance();
                if (deathChance >= 95)
                {
                    player.Father.IsDead = true;
                    engine.ConsoleManager.UserInteraction.AddAction(
                        $"Your father has passed away at the age of {player.Father.Age}");
                }
            }

            if (!player.Mother.IsDead && player.Mother.Age > 65)
            {
                var deathChance = engine.Generator.NumberGenerator.RandomChance();
                if (deathChance >= 95)
                {
                    player.Mother.IsDead = true;
                    engine.ConsoleManager.UserInteraction.AddAction(
                        $"Your mother has passed away at the age of {player.Mother.Age}");
                }
            }

            if (player.Age > 65)
            {
                var deathChance = engine.Generator.NumberGenerator.RandomChance();
                if (deathChance >= 85)
                {
                    player.IsDead = true;
                    engine.EndTheGame = true;
                    return $"You've passed away at the age of {player.Age}";
                }
            }

            if (player.Age > 20)
                player.Friends += engine.Generator.NumberGenerator.ChooseNumber(20, 100);

            switch (player.Age)
            {
                case 1:
                    engine.PlayerProgress = PlayerProgress.Baby;
                    break;
                case 7:
                    engine.PlayerProgress = PlayerProgress.Kid;
                    break;
                case 14:
                {
                    engine.CommandParser.ForceCommand("endprimaryschool");
                    engine.PlayerProgress = PlayerProgress.Teen;
                }
                    break;
                case 19:
                {
                    engine.CommandParser.ForceCommand("endhighschool");
                    engine.PlayerProgress = engine.Player.IsSuccessfulAtHighSchool
                        ? PlayerProgress.HighSchoolGraduate
                        : PlayerProgress.NonEmployed;
                }
                    break;
                case 24:
                {
                    if (engine.PlayerProgress == PlayerProgress.Student)
                    {
                        engine.CommandParser.ForceCommand("enduniversity");
                        engine.PlayerProgress = PlayerProgress.NonEmployed;
                    }
                }
                    break;
                case 35:
                {
                    var CEOChance = engine.Generator.NumberGenerator.RandomChance();
                    if (CEOChance >= 50)
                    {
                        engine.PlayerProgress = PlayerProgress.CEO;
                        engine.ConsoleManager.UserInteraction.AddAction("You've became a CEO at your company.");
                        player.Job.MonthlySalary = 20000;
                        player.IsCEO = true;
                        player.Job.EndDate = engine.GameTime;
                    }
                }
                    break;
                case 55:
                {
                    if (engine.PlayerProgress != PlayerProgress.CEO)
                        if (engine.PlayerProgress != PlayerProgress.CEO)
                        {
                            engine.PlayerProgress = PlayerProgress.Retired;
                            player.Job.EndDate = engine.GameTime;
                            player.IsRetired = true;
                            engine.ConsoleManager.UserInteraction.AddAction(
                                "You've retired from work, enjoy the rest of your life.");
                        }
                }
                    break;
            }

            return $"You have made new friends grown up the following year and now you are {player.Age} years old.";
        }
    }
}