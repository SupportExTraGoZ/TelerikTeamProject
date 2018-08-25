using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts.Utilities;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Models
{
    public class ConsoleManager : IConsoleManager
    {
        public ConsoleManager(IConsoleWriter writer, IConsoleReader reader, IConsoleCleaner cleaner,
                              IUserInteraction userInteraction, IQuestionAction questionAction)
        {
            Writer = writer;
            Reader = reader;
            Cleaner = cleaner;
            UserInteraction = userInteraction;
            QuestionAction = questionAction;
        }

        public IConsoleWriter Writer { get; }
        public IConsoleReader Reader { get; }
        public IConsoleCleaner Cleaner { get; }
        public IUserInteraction UserInteraction { get; }
        public IQuestionAction QuestionAction { get; }
    }
}