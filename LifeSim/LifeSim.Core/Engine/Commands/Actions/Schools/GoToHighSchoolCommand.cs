using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using System.Text;

namespace LifeSim.Core.Engine.Commands.Actions.Schools
{
    public class GoToHighSchoolCommand : ICommand
    {
        private const int minFriends = 50;
        private const int maxFriends = 500;
        private readonly IEngine engine;

        public GoToHighSchoolCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            // Unlock/Lock Commands
            this.engine.OptionsContainer.ChangeCommandStatus(parameters[0], false, false, true);
            this.engine.OptionsContainer.UnlockAgeUpCommand(this.engine.PlayerProgress);

            StringBuilder stringBuilder = new StringBuilder();
            if (this.engine.Player.IsSuccessfulAtPrimarySchool)
                stringBuilder.AppendLine("You have been accepted in a prestigious High School");
            else
                stringBuilder.AppendLine("You have been signed up in a not so prestigious High School");
            stringBuilder.AppendLine($"The next day, you've made {this.engine.NumberGenerator.ChooseNumber(minFriends, maxFriends)} new friends.");
            return stringBuilder.ToString();
        }
    }
}