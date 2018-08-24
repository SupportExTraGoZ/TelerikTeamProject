using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Establishments.Education.HighSchool;

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
            engine.MenuManager.OptionsContainer.ChangeCommandStatus(parameters[0], false, false, true);
            engine.MenuManager.OptionsContainer.UnlockAgeUpCommand(engine.PlayerProgress);

            engine.Player.HighSchool =
                new HighSchool(
                    engine.EducationInstitutePicker.PickHighSchool(engine.Player.IsSuccessfulAtPrimarySchool),
                    engine.GameTime.Year);

            var friends = engine.NumberGenerator.ChooseNumber(minFriends, maxFriends);
            engine.Player.Friends += friends;

            var stringBuilder = new StringBuilder();
            if (engine.Player.IsSuccessfulAtPrimarySchool)
                stringBuilder.AppendLine(
                    $"You have been accepted in the prestigious {engine.Player.HighSchool.BuildingName}.");
            else
                stringBuilder.AppendLine(
                    $"You have been accepted in the not so prestigious {engine.Player.HighSchool.BuildingName}.");
            stringBuilder.AppendLine($"The next day, you've made {friends} new friends.");
            return stringBuilder.ToString();
        }
    }
}