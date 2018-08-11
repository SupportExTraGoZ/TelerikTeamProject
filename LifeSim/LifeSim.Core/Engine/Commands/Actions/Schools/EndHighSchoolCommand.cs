using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using System.Text;

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
            var examsPercent = this.engine.NumberGenerator.RandomChance();
            if (this.engine.Player.IsTakingLessons) this.engine.Player.IsSuccessfulAtHighSchool = true;
            else if (examsPercent < 50) this.engine.Player.IsSuccessfulAtHighSchool = false;
            else this.engine.Player.IsSuccessfulAtHighSchool = true;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"You have graduated {this.engine.Player.HighSchool.Name}.");

            // Update Graduation Year of High School
            this.engine.Player.HighSchool.GraduateYear = this.engine.GameTime.Year;

            if (this.engine.Player.IsTakingLessons)
            {
                stringBuilder.AppendLine($"You've passed your exams with ease, {this.engine.NumberGenerator.ChooseNumber(80, 100)} percent.");
                this.engine.Player.IsSuccessfulAtHighSchool = true;
            }
            else if (examsPercent < 50)
            {
                stringBuilder.AppendLine($"You've struggled with your exams and barely passed them with approximately {examsPercent} percent.");
                this.engine.Player.IsSuccessfulAtHighSchool = false;
            }
            else
            {
                stringBuilder.AppendLine($"You've passed your exams with approximately {examsPercent} percent.");
                this.engine.Player.IsSuccessfulAtHighSchool = true;
            }
            return stringBuilder.ToString();
        }
    }
}