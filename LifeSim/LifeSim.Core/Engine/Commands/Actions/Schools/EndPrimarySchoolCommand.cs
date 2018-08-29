using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;

namespace LifeSim.Core.Engine.Commands.Actions.Schools
{
    public class EndPrimarySchoolCommand : ICommand
    {
        private readonly IEngine engine;

        public EndPrimarySchoolCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Name { get; set; }
        public IList<string> Parameters { get; set; }

        public string Execute()
        {
            var examsPercent = engine.Generator.NumberGenerator.RandomChance();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"You have graduated {engine.Player.PrimarySchool.BuildingName}.");
            engine.Player.HasAttendedPrimarySchool = true;

            // Update Graduation Year of Primary School
            engine.Player.PrimarySchool.GraduateYear = engine.GameTime.Year;

            if (engine.Player.HasTakenLessons)
            {
                stringBuilder.AppendLine(
                    $"You've passed your exams with ease, {engine.Generator.NumberGenerator.ChooseNumber(80, 100)} percent.");
                engine.Player.IsSuccessfulAtPrimarySchool = true;
            }
            else if (examsPercent < 50)
            {
                stringBuilder.AppendLine(
                    $"You've struggled with your exams and barely passed them with approximately {examsPercent} percent.");
                engine.Player.IsSuccessfulAtPrimarySchool = false;
            }
            else
            {
                stringBuilder.AppendLine($"You've passed your exams with approximately {examsPercent} percent.");
                engine.Player.IsSuccessfulAtPrimarySchool = true;
            }

            return stringBuilder.ToString();
        }
    }
}