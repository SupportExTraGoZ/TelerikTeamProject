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

            return $"You have grown up and now you are {player.Age} years old.";
        }
    }
}