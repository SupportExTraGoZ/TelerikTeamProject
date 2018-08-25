using System.Collections.Generic;
using System.Linq;
using Autofac;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;

namespace LifeSim.Core.Engine.Commands.Models
{
    public class CommandParser : ICommandParser
    {
        private readonly IComponentContext container;
        private readonly IEngine engine;

        public CommandParser(IEngine engine, IComponentContext container)
        {
            this.engine = engine;
            this.container = container;
        }

        public bool ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                engine.ConsoleManager.UserInteraction.AddAction("Command cannot be null or empty.");
                engine.Logger.GetLogger.Info("Client attempted to enter an empty/null command.");
                return false;
            }
            // Check for command access
            if (!engine.MenuManager.OptionsContainer.CurrentStageOptions(engine.PlayerProgress, true)
                .Contains(commandAsString.Split()[0]))
            {
                engine.ConsoleManager.UserInteraction.AddAction(
                    $"You have no access to that command. ({commandAsString})");
                return false;
            }

            var splitCommand = commandAsString.Split(' ').ToList();

            var command = engine.CommandParser.GetCommand(splitCommand[0]);
            var parameters = engine.CommandParser.ParseParameters(commandAsString);

            command.Name = commandAsString;
            command.Parameters = parameters;

            var executionResult = command.Execute();
            engine.ConsoleManager.UserInteraction.AddAction(executionResult);

            return true;
        }

        /// <summary>
        ///     Return ICommand - the command
        /// </summary>
        public ICommand GetCommand(string fullCommand)
        {
            return container.ResolveNamed<ICommand>(fullCommand.ToLower());
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();

            commandParts.RemoveAt(0);

            return !commandParts.Any() ? new List<string>() : commandParts;
        }
    }
}