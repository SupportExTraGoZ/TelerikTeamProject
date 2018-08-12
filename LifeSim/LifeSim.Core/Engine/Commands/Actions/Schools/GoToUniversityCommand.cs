using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using System.Text;
using LifeSim.Establishments.Education.HighSchool;
using LifeSim.Establishments.Education.University;

namespace LifeSim.Core.Engine.Commands.Actions.Schools
{
    public class GoToUniversityCommand : ICommand
    {
        private const int minFriends = 50;
        private const int maxFriends = 500;
        private readonly IEngine engine;

        public GoToUniversityCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            // Unlock/Lock Commands
            this.engine.OptionsContainer.ChangeCommandStatus(parameters[0], false, false, true);
            this.engine.OptionsContainer.UnlockAgeUpCommand(this.engine.PlayerProgress);

            this.engine.Player.University = new University(this.engine.EducationInstitutePicker.PickUniversity(this.engine.Player.IsSuccessfulAtHighSchool), this.engine.GameTime.Year);
            this.engine.PlayerProgress = Player.Enums.PlayerProgress.Student;

            var friends = this.engine.NumberGenerator.ChooseNumber(minFriends, maxFriends);
            this.engine.Player.Friends += friends;

            StringBuilder stringBuilder = new StringBuilder();
            if (this.engine.Player.IsSuccessfulAtHighSchool)
                stringBuilder.AppendLine($"You have been accepted in the prestigious {this.engine.Player.University.BuildingName}.");
            else
                stringBuilder.AppendLine($"You have been accepted in the not so prestigious {this.engine.Player.University.BuildingName}.");
            stringBuilder.AppendLine($"The next day, you've made {friends} new friends.");
            return stringBuilder.ToString();
        }
    }
}