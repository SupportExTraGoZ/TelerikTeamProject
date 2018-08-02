using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Factories;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Models;
using LifeSim.Player.Options.Contracts;
using LifeSim.Player.Options;
using LifeSim.Core.Engine.Core.UserQuestion.Models;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Constants;
using LifeSim.Core.Engine.Core.UserStatusDisplay;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Exceptions.Models;

namespace LifeSim.Core.Engine.Core
{
    public sealed class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private static IEngine engineInstance;

        private Engine()
        {
            // Menu Display Setup
            this.Writer = new ConsoleWriter();
            this.Reader = new ConsoleReader();
            this.Cleaner = new ConsoleCleaner();
            this.UserInteraction = new UserInteraction(Writer, Reader);
            this.MenuLauncher = new MenuLauncher(Writer, Reader);
            this.OptionsContainer = new OptionsContainer();
            this.QuestionAction = new QuestionAction(ConstQuestions.Questions, UserInteraction);
            this.UserStatus = new UserStatus(this.Writer);

            // Player Creation Setup
            this.FamilyGenerator = new FamilyGenerator();
            this.PlayerFactory = new GamePlayerFactory();
            this.PlayerProgress = PlayerProgress.NewBorn;
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

        public IConsoleReader Reader { get; set; }
        public IConsoleWriter Writer { get; set; }
        public IConsoleCleaner Cleaner { get; set; }
        public IFamilyGenerator FamilyGenerator { get; set; }
        public IMenuLauncher MenuLauncher { get; set; }
        public IUserInteraction UserInteraction { get; set; }
        public IOptionsContainer OptionsContainer { get; set; }
        public IQuestionAction QuestionAction { get; set; }
        public IUserStatus UserStatus { get; set; }
        public IGamePlayerFactory PlayerFactory { get; set; }
        public IPlayer Player { get; set; }
        public PlayerProgress PlayerProgress { get; set; }

        public void Start()
        {
            // Clear Game Console
            Cleaner.ClearConsole();

            // Show Game Logo
            Writer.PrintLogo();

            try
            {
                // Ask Questions
                var questionAnswers = QuestionAction.GetUserAnswers();

                // Player Init/Creation
                this.Player = PlayerFactory.CreatePlayer(questionAnswers[0].Answer.Split(": ")[0], questionAnswers[1].Answer.Split(": ")[0], (GenderType)Enum.Parse(typeof(GenderType), questionAnswers[2].Answer.Split(": ")[0]), (Birthplaces)Enum.Parse(typeof(Birthplaces), questionAnswers[3].Answer.Split("]")[0].Replace(" ", "")), FamilyGenerator);
            }
            catch (ArgumentException)
            {
                Writer.WriteLine("Invalid input data.");
            }
            catch (CustomException e)
            {
                Writer.WriteLine(e.Message);
            }
            finally
            {
                Writer.WriteLine("Press any key to start again...");
                Console.ReadKey();
                this.Start();
            }

            // Clears Console
            Cleaner.ClearConsole();

            while (true)
            {
                // Print Logo
                Writer.PrintLogo();

                // Show User's HUD
                this.UserStatus.WriteStatus(Player);

                // Show User's available options
                MenuLauncher.PrintMenu(PlayerProgress, OptionsContainer);

                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }

                // Clear Console
                Cleaner.ClearConsole();
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            //var command = this.Parser.ParseCommand(commandAsString);
            //var parameters = this.Parser.ParseParameters(commandAsString);

            //var executionResult = command.Execute(parameters);
            //this.Writer.WriteLine(executionResult);
        }

    }
}