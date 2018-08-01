using LifeSim.Core.CLI.Module.ConsoleUsings;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
using LifeSim.Core.Engine.Menu;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Models;
using System;
using LifeSim.Player.Enums;

namespace LifeSim.Core.Engine.Core
{
    public class Engine
    {
        //THIS CONST WILL BE MOVED TO OTHER PLACE
        private const string START_MENU_PATH = "startMenu.txt";

        // HM ABOUT THIS???
        private static readonly Engine engineInstance;

        private readonly IConsoleUsageProvider writer;
        private readonly IConsoleUsageProvider reader;
        private readonly IMenuLauncher menuServices;
        private readonly IFamilyGenerator familyGenerator;
        private PlayerProgress playerProgress;

        private Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.familyGenerator = new FamilyGenerator();
            this.playerProgress = PlayerProgress.NewBorn;
            //this.menuServices = new MenuLauncher(this.writer, this.reader);
            this.menuServices.DisplayContent(START_MENU_PATH);
        }

        public static Engine Instance
        {
            get
            {
                if (engineInstance == null)
                {
                    return new Engine();
                }

                return engineInstance;
            }
        }

        public void Start()
        {
            while (true)
            {
                switch (playerProgress)
                {
                    case PlayerProgress.NewBorn:
                        {
                            // Validate player input data, and if it's invalid
                            // Prompt the player to enter it again
                            // INFO: Pseudo Code
                            // string[] firstName lastName, Gender, Birthplace
                            // Try to use something like the past Workshop's console command reading method

                            // If Data is valid and everything is successful
                            // Change the stage of life;
                            playerProgress = PlayerProgress.Baby;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
