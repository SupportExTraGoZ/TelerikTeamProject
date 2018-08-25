using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Contracts;
using LifeSim.Logger.Contracts;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Core.Engine.Core.Contracts
{
    /// <summary>
    ///     NOTE: THIS is breaking the L in SOLID - Liskov Substitutio
    /// </summary>
    public interface IEngine
    {
        //IConsoleReader Reader { get; set; }
        //IConsoleWriter Writer { get; set; }
        //IConsoleCleaner Cleaner { get; set; }
        //IUserInteraction UserInteraction { get; set; }
        IConsoleManager ConsoleManager { get; }

        ICommandParser CommandParser { get; }

        ILogger Logger { get; set; }
        
        //IFamilyGenerator FamilyGenerator { get; set; }
        //INumberGenerator NumberGenerator { get; set; }
        //IEducationInstitutePicker EducationInstitutePicker { get; set; }
        IGenerator Generator { get; }


        //IMenuLauncher MenuLauncher { get; set; }
        //IOptionsContainer OptionsContainer { get; set; }
        IMenuManager MenuManager { get; }


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