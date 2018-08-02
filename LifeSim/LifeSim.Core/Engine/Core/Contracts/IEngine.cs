using System;
using System.Collections.Generic;
using System.Text;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Options.Contracts;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Core.Engine.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IConsoleReader Reader { get; set; }
        IConsoleWriter Writer { get; set; }
        IConsoleCleaner Cleaner { get; set; }
        IFamilyGenerator FamilyGenerator { get; set; }
        IMenuLauncher MenuLauncher { get; set; }
        IUserInteraction UserInteraction { get; set; }
        IOptionsContainer OptionsContainer { get; set; }
        IQuestionAction QuestionAction { get; set; }
        IUserStatus UserStatus { get; set; }

        IGamePlayerFactory PlayerFactory { get; set; }
        IPlayer Player { get; set; }
        PlayerProgress PlayerProgress { get; set; }
    }
}
