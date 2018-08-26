using System.Collections.Generic;
using System.Linq;
using Autofac;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;

namespace LifeSim.Core.Engine.Commands.Models
{
    public class CommandParser : ICommandParser
    {
        private readonly ILifetimeScope Scope;

        public CommandParser(ILifetimeScope scope)
        {
            // Property Injection on Engine
            // Allowance for circulating dependency
            //this.Engine = engine;
            Scope = scope;
        }

        public IEngine Engine { get; set; }

        public bool ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                Engine.ConsoleManager.UserInteraction.AddAction("Command cannot be null or empty.");
                Engine.Logger.GetLogger.Info("Client attempted to enter an empty/null command.");
                return false;
            }
            // Check for command access
            if (!Engine.MenuManager.OptionsContainer.CurrentStageOptions(Engine.PlayerProgress, true)
                .Contains(commandAsString.Split()[0]))
            {
                Engine.ConsoleManager.UserInteraction.AddAction(
                    $"You have no access to that command. ({commandAsString})");
                return false;
            }

            var splitCommand = commandAsString.Split(' ').ToList();

            var command = Engine.CommandParser.GetCommand(splitCommand[0]);
            var parameters = Engine.CommandParser.ParseParameters(commandAsString);

            command.Name = commandAsString;
            command.Parameters = parameters;

            var executionResult = command.Execute();
            Engine.ConsoleManager.UserInteraction.AddAction(executionResult);

            return true;
        }

        public void ForceCommand(string commandAsString)
        {
            var splitCommand = commandAsString.Split(' ').ToList();

            var command = Engine.CommandParser.GetCommand(splitCommand[0]);
            var parameters = Engine.CommandParser.ParseParameters(commandAsString);

            command.Name = commandAsString;
            command.Parameters = parameters;

            var executionResult = command.Execute();
            Engine.ConsoleManager.UserInteraction.AddAction(executionResult);
        }

        /// <summary>
        ///     Return ICommand - the command
        /// </summary>
        public ICommand GetCommand(string fullCommand)
        {
            return Scope.ResolveNamed<ICommand>(fullCommand.ToLower() + "command");
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();

            commandParts.RemoveAt(0);

            return !commandParts.Any() ? new List<string>() : commandParts;
        }
    }
}