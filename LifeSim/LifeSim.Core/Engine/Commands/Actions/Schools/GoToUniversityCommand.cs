using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Establishments.Education.University;
using LifeSim.Player.Enums;

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

        public string Name { get; set; }
        public IList<string> Parameters { get; set; }

        public string Execute()
        {
            // Unlock/Lock Commands
            engine.MenuManager.OptionsContainer.ChangeCommandStatus(Name, false, false, true);
            engine.MenuManager.OptionsContainer.UnlockAgeUpCommand(engine.PlayerProgress);

            engine.Player.University =
                new University(engine.Generator.EducationInstitutePicker.PickUniversity(engine.Player.IsSuccessfulAtHighSchool),
                    engine.GameTime.Year);
            engine.PlayerProgress = PlayerProgress.Student;

            var friends = engine.Generator.NumberGenerator.ChooseNumber(minFriends, maxFriends);
            engine.Player.Friends += friends;

            var stringBuilder = new StringBuilder();
            if (engine.Player.IsSuccessfulAtHighSchool)
                stringBuilder.AppendLine(
                    $"You have been accepted in the prestigious {engine.Player.University.BuildingName}.");
            else
                stringBuilder.AppendLine(
                    $"You have been accepted in the not so prestigious {engine.Player.University.BuildingName}.");
            stringBuilder.AppendLine($"The next day, you've made {friends} new friends.");
            return stringBuilder.ToString();
        }
    }
}