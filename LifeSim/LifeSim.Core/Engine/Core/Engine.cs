using System;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Factories;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu;
using LifeSim.Core.IO.Contracts;
using LifeSim.Core.WorkFunctions;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Models;

namespace LifeSim.Core.Engine.Core
{
    public sealed class Engine : IEngine
    {
        private static IEngine engineInstance;
        private readonly IConsoleCleaner cleaner;
        private readonly IFamilyGenerator familyGenerator;
        private readonly IReadable fileReader;
        private readonly IConsoleReadKey keyReader;
        private readonly IMenuLauncher menuServices;
        private readonly IConsoleReader reader;
        private readonly IUserInteraction userInteraction;

        private readonly IConsoleWriter writer;
        private readonly IGamePlayerFactory playerFactory;
        private IPlayer player;

        private PlayerProgress playerProgress;

        private Engine()
        {
            // Menu display set-up's
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.fileReader = new FileReader();
            this.cleaner = new ConsoleCleaner();
            this.userInteraction = new UserInteraction(writer, reader);
            
            this.menuServices = new MenuLauncher(writer, reader, fileReader);
           //End of Menu display functions
            this.keyReader = new ConsoleKeyReader();
          
            this.familyGenerator = new FamilyGenerator();
            this.playerFactory = new GamePlayerFactory();
            this.playerProgress = PlayerProgress.NewBorn;
        }

        public static IEngine Instance
        {
            get
            {
                if (engineInstance == null)
                    engineInstance = new Engine();

                return engineInstance;
            }
        }

        public void Start()
        {
            // Show Game Logo
            writer.PrintLogo();

            // Declaring temporary variables
            string firstName, lastName;
            string[] tempString;
            GenderType gender;
            Birthplaces birthplace;

            // Read Data
            tempString = userInteraction.AskUser("Enter your First Name: ", true).Split(": ");
            firstName = tempString[0];

            tempString = userInteraction.AskUser("Enter your Last Name: ", true).Split(": ");
            lastName = tempString[0];

            tempString = userInteraction.AskUser("Choose Gender (Male/Female): ", true).Split(": ");
            gender = (GenderType) Enum.Parse(typeof(GenderType), tempString[0]);

            birthplace = (Birthplaces) Enum.Parse(typeof(Birthplaces),
                userInteraction.AskUser("Choose Birthplace: [New York, Los Angeles, Chicago, Miami]",
                    false).Split("]")[0].Replace(" ", ""));

            // Player Init/Creation
            this.player = playerFactory.CreatePlayer(firstName, lastName, gender, birthplace, familyGenerator);
            

            // Clears Console
            cleaner.ClearConsole();

            while (true)
            {
                writer.PrintLogo();
                Console.WriteLine(
                    $"{player.FirstName} {player.LastName} | Age: {player.Age} | Gender: {player.Gender} | Birthplace: {player.Birthplace}");
                var command = keyReader.ReadKey();
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
                cleaner.ClearConsole();
            }
        }
    }
}