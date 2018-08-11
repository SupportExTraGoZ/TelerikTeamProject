using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using System.Text;
using LifeSim.Establishments.Education.PrimarySchool;

namespace LifeSim.Core.Engine.Commands.Actions.Schools
{
    public class GoToPrimarySchoolCommand : ICommand
    {
        private const int minFriends = 5;
        private const int maxFriends = 15;
        private readonly IEngine engine;

        public GoToPrimarySchoolCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            // Unlock/Lock Commands
            this.engine.OptionsContainer.ChangeCommandStatus(parameters[0], false, false, true);
            this.engine.OptionsContainer.UnlockAgeUpCommand(this.engine.PlayerProgress);

            this.engine.Player.PrimarySchool = new PrimarySchool(this.engine.EducationInstitutePicker.PickPrimarySchool(this.engine.Player.IsTakingLessons), this.engine.GameTime.Year);
            this.engine.Player.HasAttendedPrimarySchool = true;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Your parents have put you in a local school near your home.");
            stringBuilder.AppendLine("And now you are on your way to High School.");
            stringBuilder.AppendLine($"The next day, you've made {this.engine.NumberGenerator.ChooseNumber(minFriends, maxFriends)} new friends.");
            return stringBuilder.ToString();
        }
    }
}