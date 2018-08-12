using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;

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
            var player = this.engine.Player;
            if (!player.IsDead)
                player.Age++;
            if (!player.Father.IsDead)
                player.Father.Age++;
            if (!player.Mother.IsDead)
                player.Mother.Age++;

            // Update GameTime Year
            this.engine.GameTime = this.engine.GameTime.AddYears(1);

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

            if (player.Father.Age > 65)
            {
                var deathChance = this.engine.NumberGenerator.RandomChance();
                if (deathChance >= 50)
                {
                    player.Father.IsDead = true;
                    this.engine.UserInteraction.AddAction($"Your father has passed away at the age of {player.Father.Age}");
                }
            }
            if (player.Mother.Age > 65)
            {
                var deathChance = this.engine.NumberGenerator.RandomChance();
                if (deathChance >= 50)
                {
                    player.Mother.IsDead = true;
                    this.engine.UserInteraction.AddAction($"Your mother has passed away at the age of {player.Mother.Age}");
                }
            }
            if (player.Age > 65)
            {
                var deathChance = this.engine.NumberGenerator.RandomChance();
                if (deathChance >= 50)
                {
                    player.IsDead = true;
                    this.engine.EndTheGame = true;
                    return $"You've passed away at the age of {player.Age}";
                }
            }

            switch (player.Age)
            {
                case 1:
                    this.engine.PlayerProgress = Player.Enums.PlayerProgress.Baby;
                    break;
                case 7:
                    this.engine.PlayerProgress = Player.Enums.PlayerProgress.Kid;
                    break;
                case 14:
                    {
                        var tempCommand = this.engine.Parser.ParseCommand("endprimaryschool");
                        var tempParams = this.engine.Parser.ParseParameters("endprimaryschool");
                        var executionResult = tempCommand.Execute(tempParams);
                        this.engine.UserInteraction.AddAction(executionResult);

                        this.engine.PlayerProgress = Player.Enums.PlayerProgress.Teen;
                    }
                    break;
                case 19:
                    {
                        var tempCommand = this.engine.Parser.ParseCommand("endhighschool");
                        var tempParams = this.engine.Parser.ParseParameters("endhighschool");
                        var executionResult = tempCommand.Execute(tempParams);
                        this.engine.UserInteraction.AddAction(executionResult);

                        if (this.engine.Player.IsSuccessfulAtHighSchool)
                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.HighSchoolGraduate;
                        else
                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.NonEmployed;
                    }
                    break;
                case 24:
                    {
                        if (this.engine.PlayerProgress == Player.Enums.PlayerProgress.Student)
                        {
                            var tempCommand = this.engine.Parser.ParseCommand("enduniversity");
                            var tempParams = this.engine.Parser.ParseParameters("enduniversity");
                            var executionResult = tempCommand.Execute(tempParams);
                            this.engine.UserInteraction.AddAction(executionResult);

                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.NonEmployed;
                        }
                    }
                    break;
                case 35:
                    {
                        var CEOChance = this.engine.NumberGenerator.RandomChance();
                        if (CEOChance >= 50)
                        {
                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.CEO;
                            this.engine.UserInteraction.AddAction("You've became a CEO at your company.");
                            player.Job.MonthlySalary = 20000;
                            player.IsCEO = true;
                            player.Job.EndDate = this.engine.GameTime;
                        }
                    }
                    break;
                case 55:
                    {
                        if (this.engine.PlayerProgress != Player.Enums.PlayerProgress.CEO)
                        {
                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.Retired;
                            player.Job.EndDate = this.engine.GameTime;
                            player.HasJob = false;
                            player.IsRetired = true;
                            this.engine.UserInteraction.AddAction("You've retired from work, enjoy the rest of your life.");
                        }
                    }
                    break;
            }

            return $"You have grown up and now you are {player.Age} years old.";
        }
    }
}