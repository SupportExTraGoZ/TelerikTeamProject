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
using LifeSim.Player.Contracts;

namespace LifeSim.Core.Engine.Core
{
    public class Engine
    {
        private static Engine engineInstance;

        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;
        private readonly IConsoleCleaner cleaner;
        private readonly IConsoleReadKey keyReader;
        private readonly IUserInteraction userInteraction;
        private readonly IReadable fileReader;
        private readonly IMenuLauncher menuServices;
        private readonly IFamilyGenerator familyGenerator;

        private PlayerProgress playerProgress;
        private IPlayer Player;

        private Engine()
        {
            // Menu display set-up's
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.fileReader = new FileReader();
            this.cleaner = new ConsoleCleaner();
            this.userInteraction = new UserInteraction(this.writer, this.reader);

            this.menuServices = new MenuLauncher(this.writer, this.reader, this.fileReader);
            //End of Menu display functions
            this.keyReader = new ConsoleKeyReader();

            this.familyGenerator = new FamilyGenerator();
            this.playerProgress = PlayerProgress.NewBorn;

        }

        public static Engine Instance
        {
            get
            {
                if (engineInstance == null)
                {
                    engineInstance = new Engine();
                }

                return engineInstance;
            }
        }

        public void Start()
        {
            // Show Game Logo
            this.writer.PrintLogo();

            // Declaring temporary variables
            string firstName, lastName;
            string[] tempString;
            GenderType gender;
            Birthplaces birthplace;

            // Read Data
            tempString = this.userInteraction.AskUser("Enter your First Name: ", true).Split(": ");
            firstName = tempString[0];

            tempString = this.userInteraction.AskUser("Enter your Last Name: ", true).Split(": ");
            lastName = tempString[0];

            tempString = this.userInteraction.AskUser("Choose Gender (Male/Female): ", true).Split(": ");
            gender = (GenderType)Enum.Parse(typeof(GenderType), tempString[0]);

            birthplace = (Birthplaces)Enum.Parse(typeof(Birthplaces),
                                                 this.userInteraction.
                                                 AskUser("Choose Birthplace: [New York, Los Angeles, Chicago, Miami]",
                                                                              false).Split("]")[0].Replace(" ", ""));

            // Player Init/Creation
            Player = new Player.Models.Player(firstName, lastName, gender, birthplace, familyGenerator);

            // Clears Console
            this.cleaner.ClearConsole();

            while (true)
            {
                this.writer.PrintLogo();
                Console.WriteLine($"{Player.FirstName} {Player.LastName} | Age: {Player.Age} | Gender: {Player.Gender}");
                var command = this.keyReader.ReadKey();
                switch (playerProgress)
                {
                    case PlayerProgress.NewBorn:
                        {
                            // Validate player input data, and if it's invalid
                            // Prompt the player to enter it again
                            // INFO: Pseudo Code
                            // string[] firstName lastName, Gender, Birthplace

                            // If Data is valid and everything is successful
                            // Change the stage of life;
                            playerProgress = PlayerProgress.Baby;
                        }
                        break;
                    default:
                        break;
                }
                this.cleaner.ClearConsole();
            }
        }
    }
}
