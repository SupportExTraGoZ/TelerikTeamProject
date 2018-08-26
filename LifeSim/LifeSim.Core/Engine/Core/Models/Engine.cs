using System;
using System.Reflection;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Core.UserStatus.Contracts;
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

        public Engine(ICommandParser commandParser, IConsoleManager consoleManager,
            IMenuManager menuManager, IGenerator generator, ILogger logger,
            IUserStatus userStatus, IGamePlayerFactory playerFactory)
        {
            // Display Setup
            ConsoleManager = consoleManager;
            MenuManager = menuManager;
            CommandParser = commandParser;
            Logger = logger;
            Generator = generator;

            // Player Creation Setup
            UserStatus = userStatus;
            PlayerFactory = playerFactory;
            PlayerProgress = PlayerProgress.NotBorn;
        }

        public IConsoleManager ConsoleManager { get; }
        public IMenuManager MenuManager { get; }
        public ICommandParser CommandParser { get; }
        public ILogger Logger { get; }
        public IGenerator Generator { get; }

        public IUserStatus UserStatus { get; }
        public IGamePlayerFactory PlayerFactory { get; }
        public IPlayer Player { get; private set; }
        public PlayerProgress PlayerProgress { get; set; }

        public DateTime GameTime { get; set; }
        public bool EndTheGame { get; set; }

        public void Start()
        {
            // Clear Game Console
            ConsoleManager.Cleaner.ClearConsole();

            // Show Game Logo
            ConsoleManager.Writer.PrintLogo();

            try
            {
                // Ask Questions
                var questionAnswers = ConsoleManager.QuestionAction.GetUserAnswers();

                // Player Init/Creation
                Player = PlayerFactory.CreatePlayer(questionAnswers[0].Answer.Split(": ")[0],
                    questionAnswers[1].Answer.Split(": ")[0],
                    (GenderType) Enum.Parse(typeof(GenderType), questionAnswers[2].Answer.Split(": ")[0]),
                    (Birthplaces) Enum.Parse(typeof(Birthplaces),
                        questionAnswers[3].Answer.Split("]")[0].Replace(" ", "")), Generator);
            }
            catch (NullReferenceException)
            {
                SupressException(Exceptions.Models.Exceptions.AnswerRequirementsFailed);
            }
            catch (ArgumentException)
            {
                SupressException(Exceptions.Models.Exceptions.InvalidInput);
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

                    if (string.Equals(commandAsString, TerminationCommand, StringComparison.CurrentCultureIgnoreCase))
                        break;

                    CommandParser.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    // Just for now to debug, will be changed later on.
                    //ConsoleManager.UserInteraction.AddAction("An unexpected error has occured and has been logged.");
                    ConsoleManager.UserInteraction.AddAction(ex.Message);

                    Logger.GetLogger.Error(ex.Message);
                }

                // Clear Console
                ConsoleManager.Cleaner.ClearConsole();
            }

            // End Game Screen
            ConsoleManager.Cleaner.ClearConsole();

            ConsoleManager.Writer.PrintLogo();

            ConsoleManager.Writer.WriteLine(Player.ToString());

            ConsoleManager.Writer.WriteLine(
                $"Thank you for playing LifeSim Alpha {Assembly.GetExecutingAssembly().GetName().Version}");
        }

        private void SupressException(string message)
        {
            ConsoleManager.Writer.WriteLine(message);
            ConsoleManager.Writer.WriteLine(Exceptions.Models.Exceptions.StartAgainException);
            Console.ReadKey();
            Start();
        }
    }
}