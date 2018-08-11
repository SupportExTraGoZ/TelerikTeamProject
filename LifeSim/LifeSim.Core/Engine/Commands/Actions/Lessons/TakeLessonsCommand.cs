﻿using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using System.Text;

namespace LifeSim.Core.Engine.Commands.Actions.Lessons
{
    public class TakeLessonsCommand : ICommand
    {
        private const int minFriends = 5;
        private const int maxFriends = 15;
        private readonly IEngine engine;

        public TakeLessonsCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            // Unlock/Lock Commands
            this.engine.OptionsContainer.ChangeCommandStatus(parameters[0], false, false, true);

            // Set player's status
            this.engine.Player.IsTakingLessons = true;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Your parents signed you up for private lessons before school.");
            stringBuilder.AppendLine("And now you are going to do better at your exams.");
            return stringBuilder.ToString();
        }
    }
}