using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts.Utilities;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts
{
    public interface IConsoleManager
    {
        IConsoleWriter Writer { get; }
        IConsoleReader Reader { get; }
        IConsoleCleaner Cleaner { get; }
        IUserInteraction UserInteraction { get; }
        IQuestionAction QuestionAction { get; }
    }
}