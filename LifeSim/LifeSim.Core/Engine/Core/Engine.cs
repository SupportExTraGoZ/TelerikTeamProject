﻿using System;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
using LifeSim.Core.Engine.Menu;
using LifeSim.Core.IO.Contracts;
using LifeSim.Core.WorkFunctions;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Models;

namespace LifeSim.Core.Engine.Core
{
    public class Engine
    {
        private static Engine engineInstance;
        private readonly IConsoleCleaner cleaner;
        private readonly IFamilyGenerator familyGenerator;
        private readonly IReadable fileReader;
        private readonly IConsoleReadKey keyReader;
        private readonly IMenuLauncher menuServices;
        private readonly IConsoleReader reader;
        private readonly IUserInteraction userInteraction;

        private readonly IConsoleWriter writer;
        private IPlayer Player;

        private PlayerProgress playerProgress;

        private Engine()
        {
            // Menu display set-up's
            writer = new ConsoleWriter();
            reader = new ConsoleReader();
            fileReader = new FileReader();
            cleaner = new ConsoleCleaner();
            userInteraction = new UserInteraction(writer, reader);

            menuServices = new MenuLauncher(writer, reader, fileReader);
            //End of Menu display functions
            keyReader = new ConsoleKeyReader();

            familyGenerator = new FamilyGenerator();
            playerProgress = PlayerProgress.NewBorn;
        }

        public static Engine Instance
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
            Player = new Player.Models.Player(firstName, lastName, gender, birthplace, familyGenerator);

            // Clears Console
            cleaner.ClearConsole();

            while (true)
            {
                writer.PrintLogo();
                Console.WriteLine(
                    $"{Player.FirstName} {Player.LastName} | Age: {Player.Age} | Gender: {Player.Gender} | Birthplace: {Player.Birthplace}");
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