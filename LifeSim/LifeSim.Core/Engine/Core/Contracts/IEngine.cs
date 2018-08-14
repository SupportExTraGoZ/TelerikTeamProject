using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Logger.Contracts;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Options.Contracts;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Core.Engine.Core.Contracts
{
    public interface IEngine
    {
        IConsoleReader Reader { get; set; }
        IConsoleWriter Writer { get; set; }
        IParser Parser { get; set; }
        IConsoleCleaner Cleaner { get; set; }
        ILogger Logger { get; set; }
        IFamilyGenerator FamilyGenerator { get; set; }
        INumberGenerator NumberGenerator { get; set; }
        IEducationInstitutePicker EducationInstitutePicker { get; set; }
        IMenuLauncher MenuLauncher { get; set; }
        IUserInteraction UserInteraction { get; set; }
        IOptionsContainer OptionsContainer { get; set; }
        IQuestionAction QuestionAction { get; set; }
        IUserStatus UserStatus { get; set; }

        IGamePlayerFactory PlayerFactory { get; set; }
        IPlayer Player { get; set; }
        PlayerProgress PlayerProgress { get; set; }

        DateTime GameTime { get; set; }
        bool EndTheGame { get; set; }
        void Start();
    }
}