using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using System.Collections.Generic;

namespace LifeSim.Core.Engine.Core.UserQuestion
{
    public class QuestionAction
    {
        private readonly IList<IQuestion> questions;
        private readonly IUserInteraction userInteraction;

        public QuestionAction(IList<IQuestion> questions ,IUserInteraction userInteraction)
        {
            this.questions = questions;
            this.userInteraction = userInteraction;
        }

        public IList<IQuestion> GetUserAnswers(bool sameLine)
        {
            foreach (var question in this.questions)
            {
                var sendQuestion = this.userInteraction.AskUser(question.Text, sameLine);
                question.Answer = sendQuestion;
            }

            return this.questions;
        }
    }
}
