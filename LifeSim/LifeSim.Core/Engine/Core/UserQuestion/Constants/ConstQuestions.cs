using System.Collections.Generic;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Models;

namespace LifeSim.Core.Engine.Core.UserQuestion.Constants
{
    public class ConstQuestions
    {
        private const string firstName = "Enter your First Name: ";
        private const string lastName = "Enter your Last Name: ";
        private const string chooseGender = "Choose Gender (Male/Female): ";
        private const string chooseBirthplace = "Choose Birthplace: [New York, Los Angeles, Chicago, Miami]";

        public static List<IQuestion> Questions = new List<IQuestion>
        {
            new Question {Text = firstName},
            new Question {Text = lastName},
            new Question {Text = chooseGender},
            new Question {Text = chooseBirthplace, SameLine = false}
        };
    }
}