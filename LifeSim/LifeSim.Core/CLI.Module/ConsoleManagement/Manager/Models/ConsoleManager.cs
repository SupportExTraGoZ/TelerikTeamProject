using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Renderer.Contracts;

namespace LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Models
{
    public class ConsoleManager : IConsoleManager
    {
        public ConsoleManager(IConsoleRenderer renderer, IConsoleCleaner cleaner, 
                              IUserInteraction userInteraction, IQuestionAction questionAction)
        {
            Renderer = renderer;
            Cleaner = cleaner;
            UserInteraction = userInteraction;
            QuestionAction = questionAction;
        }

        public IConsoleRenderer Renderer { get; }
        public IConsoleCleaner Cleaner { get; }
        public IUserInteraction UserInteraction { get; }
        public IQuestionAction QuestionAction { get; }
    }
}