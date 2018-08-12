﻿using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using System.Text;
using LifeSim.Establishments.Education.Models.KinderGarten.Models;

namespace LifeSim.Core.Engine.Commands.Actions.Kindergarten
{
    public class GoToKinderGartenCommand : ICommand
    {
        private const int minFriends = 5;
        private const int maxFriends = 15;
        private readonly IEngine engine;

        public GoToKinderGartenCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            // Unlock/Lock Commands
            this.engine.OptionsContainer.ChangeCommandStatus(parameters[0], false, false, true);
            this.engine.OptionsContainer.UnlockAgeUpCommand(this.engine.PlayerProgress);

            this.engine.Player.KinderGarten = new KinderGarten(this.engine.EducationInstitutePicker.PickKinderGarten(), this.engine.GameTime.Year);

            var friends = this.engine.NumberGenerator.ChooseNumber(minFriends, maxFriends);
            this.engine.Player.Friends += friends;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Your parents have taken you to the local kindergarten.");
            stringBuilder.AppendLine("And now you are getting good care.");
            stringBuilder.AppendLine($"The next day, you've made {friends} new friends.");
            return stringBuilder.ToString();
        }
    }
}