using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using System.Text;

namespace LifeSim.Core.Engine.Commands.Actions.Schools
{
    public class EndUniversityCommand : ICommand
    {
        private readonly IEngine engine;

        public EndUniversityCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var examsPercent = this.engine.NumberGenerator.RandomChance();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"You have graduated {this.engine.Player.University.BuildingName}.");
            this.engine.Player.HasAttendedUniversity = true;

            // Update Graduation Year of High School
            this.engine.Player.University.GraduateYear = this.engine.GameTime.Year;

            if (this.engine.Player.IsTakingLessons)
            {
                stringBuilder.AppendLine($"You've passed your exams with ease, {this.engine.NumberGenerator.ChooseNumber(80, 100)} percent.");
                this.engine.Player.IsSuccessfulAtUniversity = true;
            }
            else if (examsPercent < 50)
            {
                stringBuilder.AppendLine($"You've struggled with your exams and barely passed them with approximately {examsPercent} percent.");
                this.engine.Player.IsSuccessfulAtUniversity = false;
            }
            else
            {
                stringBuilder.AppendLine($"You've passed your exams with approximately {examsPercent} percent.");
                this.engine.Player.IsSuccessfulAtUniversity = true;
            }
            return stringBuilder.ToString();
        }
    }
}