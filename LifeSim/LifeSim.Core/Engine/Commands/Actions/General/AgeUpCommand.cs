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
                    player.Job.MonthlySalary += 200;
                else
                    player.Job.MonthlySalary += 100;
                player.Money += player.Job.MonthlySalary * 12;
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
                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.CEO;
                    }
                    break;
            }

            return $"You have grown up and now you are {player.Age} years old.";
        }
    }
}