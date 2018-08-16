using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;

namespace LifeSim.Core.Engine.Commands.Actions.Schools
{
    public class EndHighSchoolCommand : ICommand
    {
        private readonly IEngine engine;

        public EndHighSchoolCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var examsPercent = engine.NumberGenerator.RandomChance();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"You have graduated {engine.Player.HighSchool.BuildingName}.");
            engine.Player.HasAttendedHighSchool = true;

            // Update Graduation Year of High School
            engine.Player.HighSchool.GraduateYear = engine.GameTime.Year;

            if (engine.Player.HasTakenLessons)
            {
                stringBuilder.AppendLine(
                    $"You've passed your exams with ease, {engine.NumberGenerator.ChooseNumber(80, 100)} percent.");
                engine.Player.IsSuccessfulAtHighSchool = true;
            }
            else if (examsPercent < 50)
            {
                stringBuilder.AppendLine(
                    $"You've struggled with your exams and barely passed them with approximately {examsPercent} percent.");
                engine.Player.IsSuccessfulAtHighSchool = false;
            }
            else
            {
                stringBuilder.AppendLine($"You've passed your exams with approximately {examsPercent} percent.");
                engine.Player.IsSuccessfulAtHighSchool = true;
            }
            return stringBuilder.ToString();
        }
    }
}