using System;
using System.Linq;
using System.Reflection;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Commands.Models;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Constants;
using LifeSim.Core.Engine.Core.UserQuestion.Contracts;
using LifeSim.Core.Engine.Core.UserQuestion.Models;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Models;
using LifeSim.Core.Engine.Factories;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Core.Engine.Menu.Models;
using LifeSim.Exceptions.Models;
using LifeSim.Logger.Contracts;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Options;
using LifeSim.Player.Options.Contracts;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Models;

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
            Writer = new ConsoleWriter();
            Reader = new ConsoleReader();
            Parser = new CommandParser(this);
            Cleaner = new ConsoleCleaner();
            Logger = new Logger.Models.Logger();
            UserInteraction = new UserInteraction(Writer, Reader);
            MenuLauncher = new MenuLauncher(Writer, Reader);
            OptionsContainer = new OptionsContainer();
            QuestionAction = new QuestionAction(ConstQuestions.Questions, UserInteraction);
            UserStatus = new UserStatus(Writer);

            // Player Creation Setup
            FamilyGenerator = new FamilyGenerator();
            NumberGenerator = new NumberGenerator();
            EducationInstitutePicker = new EducationInstitutePicker();
            PlayerFactory = new GamePlayerFactory();
            PlayerProgress = PlayerProgress.NotBorn;
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
        public bool EndTheGame { get; set; }

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
                Player = PlayerFactory.CreatePlayer(questionAnswers[0].Answer.Split(": ")[0],
                    questionAnswers[1].Answer.Split(": ")[0],
                    (GenderType)Enum.Parse(typeof(GenderType), questionAnswers[2].Answer.Split(": ")[0]),
                    (Birthplaces)Enum.Parse(typeof(Birthplaces),
                        questionAnswers[3].Answer.Split("]")[0].Replace(" ", "")), FamilyGenerator);
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
            GameTime = DateTime.Now;

            // Update Player's Progress to NewBorn
            PlayerProgress = PlayerProgress.NewBorn;
            UserInteraction.AddAction(
                $"You are born as {Player.FirstName} {Player.LastName} in {Player.GetBirthplace()}.");
            UserInteraction.AddAction($"Your Father is {Player.Father.FirstName} {Player.Father.LastName}");
            UserInteraction.AddAction($"Your Mother is {Player.Mother.FirstName} {Player.Mother.LastName}");

            // Clears Console
            Cleaner.ClearConsole();

            while (true)
            {
                // Print Logo
                Writer.PrintLogo();

                // Show User's HUD
                UserStatus.WriteStatus(Player);

                // Show what the user has done, last X (ActionLogNumber) actions
                UserStatus.WriteActionLog(UserInteraction.ActionLog, ActionLogNumber);

                // Show User's available options
                MenuLauncher.PrintMenu(PlayerProgress, OptionsContainer);


                if (EndTheGame)
                    break;

                try
                {
                    var commandAsString = Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                        break;

                    this.Parser.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    // Just for now to debug, will be changed later on.
                    UserInteraction.AddAction("An unexpected error has occured and has been logged.");
                    //this.UserInteraction.AddAction(ex.Message);
                    Logger.GetLogger.Error(ex.Message);
                }

                // Clear Console
                Cleaner.ClearConsole();
            }

            // TODO: Show End Game Screen
            Cleaner.ClearConsole();

            Writer.PrintLogo();

            Writer.WriteLine(Player.ToString());

            Writer.WriteLine(
                $"Thank you for playing LifeSim Alpha {Assembly.GetExecutingAssembly().GetName().Version}");
        }

        private void SupressException(string message)
        {
            Writer.WriteLine(message);
            Writer.WriteLine("Press any key to start again...");
            Console.ReadKey();
            Start();
        }
    }
}