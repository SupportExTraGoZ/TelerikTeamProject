﻿using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace LifeSim.Core.Engine.Core.UserQuestion.Models
{
    public class QuestionAction : IQuestionAction
    {
        private readonly IList<IQuestion> questions;
        private readonly IUserInteraction userInteraction;

        public QuestionAction(IList<IQuestion> questions, IUserInteraction userInteraction)
        {
            this.questions = questions;
            this.userInteraction = userInteraction;
        }

        public IList<IQuestion> GetUserAnswers()
        {
            // Old
            /*foreach (var question in this.questions)
            {
                var sendQuestion = this.userInteraction.AskUser(question.Text, question.SameLine);
                question.Answer = sendQuestion.First().ToString().ToUpper() + sendQuestion.Substring(1);
            }*/

            // New & Better - Bai Grozdan
            this.questions.ToList().ForEach(x =>
            {
                var sendQuestion = this.userInteraction.AskUser(x.Text, x.SameLine);
                if (!string.IsNullOrEmpty(x.Answer))
                    x.Answer = sendQuestion.First().ToString().ToUpper() + sendQuestion.Substring(1);
            });

            return this.questions;
        }
    }
}
