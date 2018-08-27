using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Establishments.Education.Models.KinderGarten.Models;

namespace LifeSim.Core.Engine.Commands.Actions.Kindergarten
{
    public class GoToKinderGartenCommand : ICommand
    {
        private const int minFriends = 5;
        private const int maxFriends = 15;
        private readonly IEngine engine;
        private readonly IGameFactory factory;

        public GoToKinderGartenCommand(IEngine engine, IGameFactory factory)
        {
            this.engine = engine;
            this.factory = factory;
        }

        public string Name { get; set; }
        public IList<string> Parameters { get; set; }

        public string Execute()
        {
            // Unlock/Lock Commands
            engine.MenuManager.OptionsContainer.ChangeCommandStatus(Name, false, false, true);
            engine.MenuManager.OptionsContainer.UnlockAgeUpCommand(engine.PlayerProgress);

            this.engine.Player.KinderGarten =
                this.factory.EducationalInstituteFactory.CreateKinderGarten(this.engine.Generator.EducationInstitutePicker.PickKinderGarten()
                ,engine.GameTime.Year);

            var friends = engine.Generator.NumberGenerator.ChooseNumber(minFriends, maxFriends);
            engine.Player.Friends += friends;

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Your parents have taken you to the local kindergarten.");
            stringBuilder.AppendLine("And now you are getting good care.");
            stringBuilder.AppendLine($"The next day, you've made {friends} new friends.");
            return stringBuilder.ToString();
        }
    }
}