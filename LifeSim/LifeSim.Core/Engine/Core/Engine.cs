using System;
using LifeSim.Core.CLI.Module.ConsoleUsings.Contracts;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
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
using LifeSim.Core.Engine.Menu.Logo;

namespace LifeSim.Core.Engine.Core
{
    public sealed class Engine : IEngine
    {
        private static IEngine engineInstance;
        private readonly IConsoleCleaner cleaner;
        private readonly IFamilyGenerator familyGenerator;
        private readonly IConsoleReadKey keyReader;
        private readonly IMenuLauncher menuServices;
        private readonly IConsoleReader reader;
        private readonly IUserInteraction userInteraction;
        private readonly IOptionsContainer optionsContainer;
        private readonly IQuestionAction questionAction;

        private readonly IConsoleWriter writer;
        private readonly IGamePlayerFactory playerFactory;
        private IPlayer player;

        private PlayerProgress playerProgress;

        private Engine()
        {
            // Menu display set-up's
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.cleaner = new ConsoleCleaner();
            this.userInteraction = new UserInteraction(writer, reader);
            this.menuServices = new MenuLauncher(writer, reader);
            this.keyReader = new ConsoleKeyReader();
            this.optionsContainer = new OptionsContainer();
            this.questionAction = new QuestionAction(ConstQuestions.Questions, userInteraction);

            // Player Creation Setup
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

            // Ask Questions
            var questionAnswers = questionAction.GetUserAnswers();

            // Player Init/Creation
            this.player = playerFactory.CreatePlayer(questionAnswers[0].Answer.Split(": ")[0], questionAnswers[1].Answer.Split(": ")[0], (GenderType)Enum.Parse(typeof(GenderType), questionAnswers[2].Answer.Split(": ")[0]), (Birthplaces)Enum.Parse(typeof(Birthplaces), questionAnswers[3].Answer.Split("]")[0].Replace(" ", "")), familyGenerator);

            // Clears Console
            cleaner.ClearConsole();

            while (true)
            {
                //Set Console cursor position at center and print Logo
                //writer.SetCenterCursorPosition(Logo.GetLogo());
                writer.PrintLogo();

                writer.WriteLine($"{new string('=', 30)} Stats {new string('=', 30)}");
                writer.WriteLine($"Father: {player.Father.FirstName} {player.Father.LastName} | Age: {player.Father.Age} | Birthplace: {player.Father.GetBirthplace()}");
                writer.WriteLine($"Mother: {player.Mother.FirstName} {player.Mother.LastName} | Age: {player.Father.Age} | Birthplace: {player.Mother.GetBirthplace()}");
                writer.WriteLine(
                    $"You: {player.FirstName} {player.LastName} | Age: {player.Age} | Gender: {player.Gender} | Birthplace: {player.GetBirthplace()}");
                writer.WriteLine($"{new string('=', 67)}");

                menuServices.PrintMenu(playerProgress, optionsContainer);
                var command = keyReader.ReadKey();

                cleaner.ClearConsole();
            }
        }
    }
}