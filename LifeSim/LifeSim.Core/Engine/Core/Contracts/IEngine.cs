using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.UserStatus.Contracts;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Contracts;
using LifeSim.Logger.Contracts;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Core.Engine.Core.Contracts
{
    public interface IEngine
    {
        IConsoleManager ConsoleManager { get; }
        IMenuManager MenuManager { get; }
        ICommandParser CommandParser { get; }
        ILogger Logger { get; }
        IGenerator Generator { get; }

        IUserStatus UserStatus { get; }
        IGameFactory GameFactory { get; }
        IPlayer Player { get; }
        PlayerProgress PlayerProgress { get; set; }

        DateTime GameTime { get; set; }
        bool EndTheGame { get; set; }
        void Start();
    }
}