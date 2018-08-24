using System;
using System.Linq;
using System.Reflection;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
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
        //private static IEngine engineInstance;

        private readonly ICommandParser commandParser;
        private readonly IConsoleManager consoleManager;

        private Engine(ICommandParser commandParser,IConsoleManager consoleManager)
        {
            // Menu Display Setup
            //Writer = new ConsoleWriter();
            //Reader = new ConsoleReader();
            //Cleaner = new ConsoleCleaner();
            //UserInteraction = new UserInteraction(Writer, Reader);

            //consoleManager with all functionalities from Menu Display
            this.consoleManager = consoleManager;
           

            Logger = new Logger.Models.Logger();

            MenuLauncher = new MenuLauncher(this.ConsoleManager.Renderer.Writer, this.ConsoleManager.Renderer.Reader);
            OptionsContainer = new OptionsContainer();

            QuestionAction = new QuestionAction(ConstQuestions.Questions, this.ConsoleManager.UserInteraction);


            FamilyGenerator = new FamilyGenerator();
            NumberGenerator = new NumberGenerator();
            EducationInstitutePicker = new EducationInstitutePicker();

            // Player Creation Setup
            UserStatus = new UserStatus(this.ConsoleManager.Renderer.Writer);
            PlayerFactory = new GamePlayerFactory();
            PlayerProgress = PlayerProgress.NotBorn;

            this.commandParser = commandParser;
        }

        //public static IEngine Instance
        //{
        //    get
        //    {
        //        if (engineInstance == null)
        //            engineInstance = new Engine();

        //        return engineInstance;
        //    }
        //}

        //public IConsoleReader Reader { get; set; }
        //public IConsoleWriter Writer { get; set; }
        //public IConsoleCleaner Cleaner { get; set; }
        //public IUserInteraction UserInteraction { get; set; }

        public IConsoleManager ConsoleManager { get; }

        public ICommandParser CommandParser { get; }


        public ILogger Logger { get; set; }
        public IFamilyGenerator FamilyGenerator { get; set; }
        public INumberGenerator NumberGenerator { get; set; }
        public IEducationInstitutePicker EducationInstitutePicker { get; set; }
        public IMenuLauncher MenuLauncher { get; set; }
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
            this.ConsoleManager.Cleaner.ClearConsole();

            // Show Game Logo
            //Writer.PrintLogo();
            this.ConsoleManager.Renderer.Writer.PrintLogo();

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
            this.ConsoleManager.UserInteraction.AddAction(
                $"You are born as {Player.FirstName} {Player.LastName} in {Player.GetBirthplace()}.");
            this.ConsoleManager.UserInteraction.AddAction($"Your Father is {Player.Father.FirstName} {Player.Father.LastName}");
            this.ConsoleManager.UserInteraction.AddAction($"Your Mother is {Player.Mother.FirstName} {Player.Mother.LastName}");

            // Clears Console
            //Cleaner.ClearConsole();
            this.ConsoleManager.Cleaner.ClearConsole();


            while (true)
            {
                // Print Logo
                this.ConsoleManager.Renderer.Writer.PrintLogo();

                // Show User's HUD
                UserStatus.WriteStatus(Player);

                // Show what the user has done, last X (ActionLogNumber) actions
                UserStatus.WriteActionLog(this.ConsoleManager.UserInteraction.ActionLog, ActionLogNumber);

                // Show User's available options
                MenuLauncher.PrintMenu(PlayerProgress, OptionsContainer);


                if (EndTheGame)
                    break;

                try
                {
                    var commandAsString = this.ConsoleManager.Renderer.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                        break;

                    this.CommandParser.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    // Just for now to debug, will be changed later on.
                    this.ConsoleManager.UserInteraction.AddAction("An unexpected error has occured and has been logged.");
                    //this.UserInteraction.AddAction(ex.Message);

                    Logger.GetLogger.Error(ex.Message);
                }

                // Clear Console
                //Cleaner.ClearConsole();
                this.ConsoleManager.Cleaner.ClearConsole();
            }

            // TODO: Show End Game Screen
            //Cleaner.ClearConsole();
            this.ConsoleManager.Cleaner.ClearConsole();

            //Writer.PrintLogo();
            this.ConsoleManager.Renderer.Writer.PrintLogo();

            //Writer.WriteLine(Player.ToString());
            this.ConsoleManager.Renderer.Writer.WriteLine(Player.ToString());

            this.ConsoleManager.Renderer.Writer.WriteLine(
                $"Thank you for playing LifeSim Alpha {Assembly.GetExecutingAssembly().GetName().Version}");
        }

        private void SupressException(string message)
        {
            this.ConsoleManager.Renderer.Writer.WriteLine(message);
            this.ConsoleManager.Renderer.Writer.WriteLine("Press any key to start again...");
            Console.ReadKey();
            Start();
        }
    }
}