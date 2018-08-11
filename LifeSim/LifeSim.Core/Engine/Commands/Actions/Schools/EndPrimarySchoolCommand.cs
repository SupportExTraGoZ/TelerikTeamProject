using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using System.Text;

namespace LifeSim.Core.Engine.Commands.Actions.Schools
{
    public class EndPrimarySchoolCommand : ICommand
    {
        private readonly IEngine engine;

        public EndPrimarySchoolCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var examsPercent = this.engine.NumberGenerator.RandomChance();
            if (this.engine.Player.IsTakingLessons) this.engine.Player.IsSuccessfulAtPrimarySchool = true;
            else if (examsPercent < 50) this.engine.Player.IsSuccessfulAtPrimarySchool = false;
            else this.engine.Player.IsSuccessfulAtPrimarySchool = true;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"You have graduated {this.engine.Player.PrimarySchool.Name}.");

            // Update Graduation Year of Primary School
            this.engine.Player.PrimarySchool.GraduateYear = this.engine.GameTime.Year;

            if (this.engine.Player.IsTakingLessons)
            {
                stringBuilder.AppendLine($"You've passed your exams with ease, {this.engine.NumberGenerator.ChooseNumber(80, 100)} percent.");
            }
            else if (examsPercent < 50)
            {
                stringBuilder.AppendLine($"You've struggled with your exams and barely passed them with approximately {examsPercent} percent.");
            }
            else
            {
                stringBuilder.AppendLine($"You've passed your exams with approximately {examsPercent} percent.");
            }
            return stringBuilder.ToString();
        }
    }
}