using System.Collections.Generic;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts
{
    public interface IQuestionAction
    {
        IList<IQuestion> GetUserAnswers();
    }
}