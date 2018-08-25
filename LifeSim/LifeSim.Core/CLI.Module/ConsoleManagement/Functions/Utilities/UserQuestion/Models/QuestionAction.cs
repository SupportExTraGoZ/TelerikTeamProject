using System.Collections.Generic;
using System.Linq;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts.Utilities;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Constants;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Models
{
    public class QuestionAction : IQuestionAction
    {
        private readonly IList<IQuestion> questions;
        private readonly IUserInteraction userInteraction;

        public QuestionAction(IUserInteraction userInteraction)
        {
            this.questions = ConstQuestions.Questions;
            this.userInteraction = userInteraction;
        }

        public IList<IQuestion> GetUserAnswers()
        {
            // New & Better - Bai Grozdan
            questions.ToList().ForEach(x =>
            {
                var sendQuestion = userInteraction.AskUser(x.Text, x.SameLine);
                if (!string.IsNullOrEmpty(sendQuestion))
                    x.Answer = sendQuestion.First().ToString().ToUpper() + sendQuestion.Substring(1);
            });

            return questions;
        }
    }
}