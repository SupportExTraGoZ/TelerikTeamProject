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

        public string Execute(IList<string> parameters)
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
                var deathChance = this.engine.NumberGenerator.RandomChance();
                if (deathChance >= 70)
                {
                    player.Father.IsDead = true;
                    engine.UserInteraction.AddAction($"Your father has passed away at the age of {player.Father.Age}");
                }
            }
            if (!player.Mother.IsDead && player.Mother.Age > 65)
            {
                var deathChance = this.engine.NumberGenerator.RandomChance();
                if (deathChance >= 70)
                {
                    player.Mother.IsDead = true;
                    engine.UserInteraction.AddAction($"Your mother has passed away at the age of {player.Mother.Age}");
                }
            }
            if (player.Age > 65)
            {
                var deathChance = this.engine.NumberGenerator.RandomChance();
                if (deathChance >= 70)
                {
                    player.IsDead = true;
                    engine.EndTheGame = true;
                    return $"You've passed away at the age of {player.Age}";
                }
            }
            if (player.Age > 20)
            {
                player.Friends += this.engine.NumberGenerator.ChooseNumber(20, 100);
            }

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
                    var tempCommand = engine.Parser.ParseCommand("endprimaryschool");
                    var tempParams = engine.Parser.ParseParameters("endprimaryschool");
                    var executionResult = tempCommand.Execute(tempParams);
                    engine.UserInteraction.AddAction(executionResult);

                    engine.PlayerProgress = PlayerProgress.Teen;
                }
                    break;
                case 19:
                {
                    var tempCommand = engine.Parser.ParseCommand("endhighschool");
                    var tempParams = engine.Parser.ParseParameters("endhighschool");
                    var executionResult = tempCommand.Execute(tempParams);
                    engine.UserInteraction.AddAction(executionResult);

                    if (engine.Player.IsSuccessfulAtHighSchool)
                        engine.PlayerProgress = PlayerProgress.HighSchoolGraduate;
                    else
                        engine.PlayerProgress = PlayerProgress.NonEmployed;
                }
                    break;
                case 24:
                {
                    if (engine.PlayerProgress == PlayerProgress.Student)
                    {
                        var tempCommand = engine.Parser.ParseCommand("enduniversity");
                        var tempParams = engine.Parser.ParseParameters("enduniversity");
                        var executionResult = tempCommand.Execute(tempParams);
                        engine.UserInteraction.AddAction(executionResult);

                        engine.PlayerProgress = PlayerProgress.NonEmployed;
                    }
                }
                    break;
                case 35:
                {
                    var CEOChance = engine.NumberGenerator.RandomChance();
                    if (CEOChance >= 50)
                    {
                        engine.PlayerProgress = PlayerProgress.CEO;
                        engine.UserInteraction.AddAction("You've became a CEO at your company.");
                        player.Job.MonthlySalary = 20000;
                        player.IsCEO = true;
                        player.Job.EndDate = engine.GameTime;
                    }
                }
                    break;
                case 55:
                {
                    if (engine.PlayerProgress != PlayerProgress.CEO)
                    {
                        if (this.engine.PlayerProgress != Player.Enums.PlayerProgress.CEO)
                        {
                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.Retired;
                            player.Job.EndDate = this.engine.GameTime;
                            player.IsRetired = true;
                            this.engine.UserInteraction.AddAction("You've retired from work, enjoy the rest of your life.");
                        }
                    }
                }
                    break;
            }

            return $"You have made new friends grown up the following year and now you are {player.Age} years old.";
        }
    }
}