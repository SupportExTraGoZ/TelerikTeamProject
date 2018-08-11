using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;

namespace LifeSim.Core.Engine.Commands.Actions
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

            switch (player.Age)
            {
                case 1:
                    this.engine.PlayerProgress = Player.Enums.PlayerProgress.Baby;
                    break;
                case 6:
                    this.engine.PlayerProgress = Player.Enums.PlayerProgress.Kid;
                    break;
                case 13:
                    {
                        // Unfinished
                        var tempCommand = this.engine.Parser.ParseCommand("endprimaryschool");
                        var tempParams = this.engine.Parser.ParseParameters("endprimaryschool");
                        var executionResult = tempCommand.Execute(tempParams);
                        this.engine.UserInteraction.AddAction(executionResult);

                        this.engine.PlayerProgress = Player.Enums.PlayerProgress.Teen;
                    }
                    break;
                case 18:
                    {
                        // Unfinished
                        var tempCommand = this.engine.Parser.ParseCommand("endhighschool");
                        var tempParams = this.engine.Parser.ParseParameters("endhighschool");
                        var executionResult = tempCommand.Execute(tempParams);
                        this.engine.UserInteraction.AddAction(executionResult);

                        this.engine.PlayerProgress = Player.Enums.PlayerProgress.HighSchoolGraduate;
                    }
                    break;
            }

            return $"You have grown up and now you are {player.Age} years old.";
        }
    }
}