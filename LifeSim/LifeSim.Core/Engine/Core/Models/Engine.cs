using System;
using System.Reflection;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Models;
using LifeSim.Core.Engine.Factories;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Contracts;
using LifeSim.Exceptions.Models;
using LifeSim.Logger.Contracts;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Core.Engine.Core.Models
{
    public sealed class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";

        private const int ActionLogNumber = 5;

        private Engine(ICommandParser commandParser, IConsoleManager consoleManager,
                       IMenuManager menuManager, IGenerator generator, ILogger logger,
                       IUserStatus userStatus, IGamePlayerFactory playerFactory)
        {
            // Menu Display Setup
            //Writer = new ConsoleWriter();
            //Reader = new ConsoleReader();
            //Cleaner = new ConsoleCleaner();
            //UserInteraction = new UserInteraction(Writer, Reader);
            //QuestionAction = new QuestionAction(ConstQuestions.Questions, ConsoleManager.UserInteraction);

            //consoleManager with all functionalities from Menu Display
            this.ConsoleManager = consoleManager;

            //MenuLauncher = new MenuLauncher(this.ConsoleManager.Writer, this.ConsoleManager.Reader);
            //OptionsContainer = new OptionsContainer();
            this.MenuManager = menuManager;

            Logger = logger;

            //FamilyGenerator = new FamilyGenerator();
            //NumberGenerator = new NumberGenerator();
            //EducationInstitutePicker = new EducationInstitutePicker();
            this.Generator = generator;

            // Player Creation Setup
            //UserStatus = new UserStatus(ConsoleManager.Writer);
            UserStatus = userStatus;
            //PlayerFactory = new GamePlayerFactory();
            PlayerFactory = playerFactory;

            PlayerProgress = PlayerProgress.NotBorn;

            this.CommandParser = commandParser;
        }

        //public IConsoleReader Reader { get; set; }
        //public IConsoleWriter Writer { get; set; }
        //public IConsoleCleaner Cleaner { get; set; }
        //public IUserInteraction UserInteraction { get; set; }

        public IConsoleManager ConsoleManager { get; }

        public ICommandParser CommandParser { get; }

        public ILogger Logger { get; set; }

        //public IFamilyGenerator FamilyGenerator { get; set; }
        //public INumberGenerator NumberGenerator { get; set; }
        //public IEducationInstitutePicker EducationInstitutePicker { get; set; }
        public IGenerator Generator { get; }

        //public IMenuLauncher MenuLauncher { get; set; }
        //public IOptionsContainer OptionsContainer { get; set; }
        //public IQuestionAction QuestionAction { get; set; }
        public IMenuManager MenuManager { get; }

        public IUserStatus UserStatus { get; set; }
        public IGamePlayerFactory PlayerFactory { get; set; }
        public IPlayer Player { get; set; }
        public PlayerProgress PlayerProgress { get; set; }

        public DateTime GameTime { get; set; }
        public bool EndTheGame { get; set; }

        public void Start()
        {
            // Clear Game Console
            ConsoleManager.Cleaner.ClearConsole();

            // Show Game Logo
            //Writer.PrintLogo();
            ConsoleManager.Writer.PrintLogo();

            try
            {
                // Ask Questions
                var questionAnswers = ConsoleManager.QuestionAction.GetUserAnswers();

                // Player Init/Creation
                Player = PlayerFactory.CreatePlayer(questionAnswers[0].Answer.Split(": ")[0],
                    questionAnswers[1].Answer.Split(": ")[0],
                    (GenderType)Enum.Parse(typeof(GenderType), questionAnswers[2].Answer.Split(": ")[0]),
                    (Birthplaces)Enum.Parse(typeof(Birthplaces),
                        questionAnswers[3].Answer.Split("]")[0].Replace(" ", "")), Generator.FamilyGenerator);
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
            ConsoleManager.UserInteraction.AddAction(
                $"You are born as {Player.FirstName} {Player.LastName} in {Player.GetBirthplace()}.");
            ConsoleManager.UserInteraction.AddAction(
                $"Your Father is {Player.Father.FirstName} {Player.Father.LastName}");
            ConsoleManager.UserInteraction.AddAction(
                $"Your Mother is {Player.Mother.FirstName} {Player.Mother.LastName}");

            // Clears Console
            //Cleaner.ClearConsole();
            ConsoleManager.Cleaner.ClearConsole();

            while (true)
            {
                // Print Logo
                ConsoleManager.Writer.PrintLogo();

                // Show User's HUD
                UserStatus.WriteStatus(Player);

                // Show what the user has done, last X (ActionLogNumber) actions
                UserStatus.WriteActionLog(ConsoleManager.UserInteraction.ActionLog, ActionLogNumber);

                // Show User's available options
                MenuManager.MenuLauncher.PrintMenu(PlayerProgress, MenuManager.OptionsContainer);

                if (EndTheGame)
                    break;

                try
                {
                    var commandAsString = ConsoleManager.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                        break;

                    CommandParser.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    // Just for now to debug, will be changed later on.
                    ConsoleManager.UserInteraction.AddAction("An unexpected error has occured and has been logged.");
                    //this.UserInteraction.AddAction(ex.Message);

                    Logger.GetLogger.Error(ex.Message);
                }

                // Clear Console
                //Cleaner.ClearConsole();
                ConsoleManager.Cleaner.ClearConsole();
            }

            // TODO: Show End Game Screen
            ConsoleManager.Cleaner.ClearConsole();

            ConsoleManager.Writer.PrintLogo();

            ConsoleManager.Writer.WriteLine(Player.ToString());

            ConsoleManager.Writer.WriteLine(
                $"Thank you for playing LifeSim Alpha {Assembly.GetExecutingAssembly().GetName().Version}");
        }

        private void SupressException(string message)
        {
            ConsoleManager.Writer.WriteLine(message);
            ConsoleManager.Writer.WriteLine("Press any key to start again...");
            Console.ReadKey();
            Start();
        }
    }
}