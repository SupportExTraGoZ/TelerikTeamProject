using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
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
            engine.MenuManager.OptionsContainer.ChangeCommandStatus(parameters[0], false, false, true);
            engine.MenuManager.OptionsContainer.UnlockAgeUpCommand(engine.PlayerProgress);

            engine.Player.PrimarySchool =
                new PrimarySchool(engine.Generator.EducationInstitutePicker.PickPrimarySchool(engine.Player.HasTakenLessons),
                    engine.GameTime.Year);

            var friends = engine.Generator.NumberGenerator.ChooseNumber(minFriends, maxFriends);
            engine.Player.Friends += friends;

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Your parents have put you in a local school near your home.");
            stringBuilder.AppendLine("And now you are on your way to High School.");
            stringBuilder.AppendLine($"The next day, you've made {friends} new friends.");
            return stringBuilder.ToString();
        }
    }
}