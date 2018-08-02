using System;
using System.Collections.Generic;

namespace LifeSim.Core.Engine.Core.UserQuestion.Contracts
{
    public interface IQuestionAction
    {
        IList<IQuestion> GetUserAnswers();
    }
}
