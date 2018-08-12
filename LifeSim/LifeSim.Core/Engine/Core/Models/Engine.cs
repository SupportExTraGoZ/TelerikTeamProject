using System;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Factories;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Models;
using LifeSim.Player.Options.Contracts;
using LifeSim.Player.Options;
using LifeSim.Core.Engine.Core.UserQuestion.Models;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Constants;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Exceptions.Models;
using LifeSim.Logger.Contracts;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Commands.Models;
using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Core.Engine.Menu.Models;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Models;
using System.Linq;
using System.Reflection;

namespace LifeSim.Core.Engine.Core.Models
{
    public sealed class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const int ActionLogNumber = 5;
        private static IEngine engineInstance;

        private Engine()
        {
            // Menu Display Setup
            this.Writer = new ConsoleWriter();
            this.Reader = new ConsoleReader();
            this.Parser = new CommandParser();
            this.Cleaner = new ConsoleCleaner();
            this.Logger = new Logger.Models.Logger();
            this.UserInteraction = new UserInteraction(this.Writer, this.Reader);
            this.MenuLauncher = new MenuLauncher(this.Writer, this.Reader);
            this.OptionsContainer = new OptionsContainer();
            this.QuestionAction = new QuestionAction(ConstQuestions.Questions, UserInteraction);
            this.UserStatus = new UserStatus(this.Writer);

            // Player Creation Setup
            this.FamilyGenerator = new FamilyGenerator();
            this.NumberGenerator = new NumberGenerator();
            this.EducationInstitutePicker = new EducationInstitutePicker();
            this.PlayerFactory = new GamePlayerFactory();
            this.PlayerProgress = PlayerProgress.NotBorn;
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
        public IParser Parser { get; set; }
        public IConsoleCleaner Cleaner { get; set; }
        public ILogger Logger { get; set; }
        public IFamilyGenerator FamilyGenerator { get; set; }
        public INumberGenerator NumberGenerator { get; set; }
        public IEducationInstitutePicker EducationInstitutePicker { get; set; }
        public IMenuLauncher MenuLauncher { get; set; }
        public IUserInteraction UserInteraction { get; set; }
        public IOptionsContainer OptionsContainer { get; set; }
        public IQuestionAction QuestionAction { get; set; }
        public IUserStatus UserStatus { get; set; }
        public IGamePlayerFactory PlayerFactory { get; set; }
        public IPlayer Player { get; set; }
        public PlayerProgress PlayerProgress { get; set; }

        public DateTime GameTime { get; set; }

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
            catch (NullReferenceException)
            {
                SupressException("Your answers didn't meet the requirements. Try Again...");
            }
            catch (ArgumentException)
            {
                SupressException("Invalid input data.");
            }
            catch (CustomException e)
            {
                SupressException(e.Message);
            }

            // Update GameTime
            this.GameTime = DateTime.Now;

            // Update Player's Progress to NewBorn
            this.PlayerProgress = PlayerProgress.NewBorn;
            this.UserInteraction.AddAction($"You are born as {this.Player.FirstName} {this.Player.LastName} in {this.Player.GetBirthplace()}.");
            this.UserInteraction.AddAction($"Your Father is {this.Player.Father.FirstName} {this.Player.Father.LastName}");
            this.UserInteraction.AddAction($"Your Mother is {this.Player.Mother.FirstName} {this.Player.Mother.LastName}");

            // Clears Console
            this.Cleaner.ClearConsole();

            while (true)
            {
                // Print Logo
                this.Writer.PrintLogo();

                // Show User's HUD
                this.UserStatus.WriteStatus(Player);

                // Show what the user has done, last X (ActionLogNumber) actions
                this.UserStatus.WriteActionLog(this.UserInteraction.ActionLog, ActionLogNumber);

                // Show User's available options
                MenuLauncher.PrintMenu(PlayerProgress, OptionsContainer);

                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    // TODO: If process command doesn't go thru, show the options again...
                    /*if (!this.ProcessCommand(commandAsString))
                    {

                    }*/

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    // Just for now to debug, will be changed later on.
                    //this.UserInteraction.AddAction("An unexpected error has occured and has been logged.");
                    this.UserInteraction.AddAction(ex.Message);
                    this.Logger.GetLogger.Error(ex.Message);
                }

                // Clear Console
                this.Cleaner.ClearConsole();
            }

            // TODO: Show End Game Screen
            this.Cleaner.ClearConsole();

            this.Writer.PrintLogo();

            this.Writer.WriteLine(this.Player.ToString());

            this.Writer.WriteLine($"Thank you for playing LifeSim Alpha {Assembly.GetExecutingAssembly().GetName().Version.ToString()}");
        }

        private bool ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                this.UserInteraction.AddAction("Command cannot be null or empty.");
                this.Logger.GetLogger.Info("Client attempted to enter an empty/null command.");
                return false;
            }
            // Check for command access
            if (!this.OptionsContainer.CurrentStageOptions(PlayerProgress, true).Contains(commandAsString))
            {
                this.UserInteraction.AddAction($"You have no access to that command. ({commandAsString})");
                return false;
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.UserInteraction.AddAction(executionResult);

            return true;
        }

        private void SupressException(string message)
        {
            this.Writer.WriteLine(message);
            this.Writer.WriteLine("Press any key to start again...");
            Console.ReadKey();
            this.Start();
        }
    }
}