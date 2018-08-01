using LifeSim.Core.CLI.Module.ConsoleUsings;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
using LifeSim.Core.Engine.Menu;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Models;
using System;
using LifeSim.Player.Enums;
using LifeSim.Core.IO.Contracts;
using LifeSim.Core.WorkFunctions;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using System.IO;
using System.Linq;

namespace LifeSim.Core.Engine.Core
{
    public class Engine
    {

        // HM ABOUT THIS???
        private static readonly Engine engineInstance;

        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;
        private readonly IReadable fileReader;
        private readonly IMenuLauncher menuServices;
        private readonly IFamilyGenerator familyGenerator;
        private PlayerProgress playerProgress;

        private Engine()
        {
            // Menu display set-up's
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.fileReader = new FileReader();
            this.menuServices = new MenuLauncher(this.writer, this.reader, this.fileReader);
            //End of Menu display functions

            this.familyGenerator = new FamilyGenerator();
            this.playerProgress = PlayerProgress.NewBorn;

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
                this.writer.PrintLogo();
                switch (playerProgress)
                {
                    case PlayerProgress.NewBorn:
                        {
                            // Validate player input data, and if it's invalid
                            // Prompt the player to enter it again
                            // INFO: Pseudo Code
                            // string[] firstName lastName, Gender, Birthplace
                            /*string firstName, lastName;
                            GenderType gender;
                            Birthplaces birthplace;
                            // Read Data
                            Console.WriteLine("Enter your First Name:");
                            firstName = Console.ReadLine();
                            this.menuServices.DisplayContent(path);
                            this.writer.ClearConsole();
                            Console.WriteLine("Enter your Last Name:");
                            lastName = Console.ReadLine();
                            this.menuServices.DisplayContent(path);
                            this.writer.ClearConsole();*/

                            // If Data is valid and everything is successful
                            // Change the stage of life;
                            playerProgress = PlayerProgress.Baby;
                        }
                        break;
                    default:
                        break;
                }
                this.writer.ClearConsole();
            }
        }
    }
}
