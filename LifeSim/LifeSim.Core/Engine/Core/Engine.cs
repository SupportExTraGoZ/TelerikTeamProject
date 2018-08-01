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

        // HM ABOUT THIS???
        private static readonly Engine engineInstance;

        private readonly IConsoleWriter writer;
        private readonly IConsoleReader reader;
        private readonly IConsoleCleaner cleaner;
        private readonly IReadable fileReader;
        private readonly IMenuLauncher menuServices;
        private readonly IConsoleReadKey keyReader;
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
                    return new Engine();
                }

                return engineInstance;
            }
        }

        public void Start()
        {
            this.writer.PrintLogo();
            string firstName, lastName;
            string[] tempString;
            GenderType gender;
            Birthplaces birthplace;
            // Read Data
            Console.Write("Enter your First Name: ");
            tempString = Console.ReadLine().Split(": ");
            firstName = tempString[0];

            Console.Write("Enter your Last Name: ");
            tempString = Console.ReadLine().Split(": ");
            lastName = tempString[0];

            Console.Write("Choose Gender (Male/Female): ");
            tempString = Console.ReadLine().Split(": ");
            gender = (GenderType)Enum.Parse(typeof(GenderType), tempString[0]);

            Console.WriteLine("Choose Birthplace: [New York, Los Angeles, Chicago, Miami]");
            birthplace = (Birthplaces)Enum.Parse(typeof(Birthplaces), Console.ReadLine().Replace(" ", ""));

            Player = new Player.Models.Player(firstName, lastName, gender, birthplace, familyGenerator);

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
