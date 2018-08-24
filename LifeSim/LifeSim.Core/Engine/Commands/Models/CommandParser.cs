using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Exceptions.Models;
using LifeSim.Core.Engine.Core.Contracts;
using Autofac;

namespace LifeSim.Core.Engine.Commands.Models
{
    public class CommandParser : ICommandParser
    {
        private readonly IEngine engine;

        private readonly IComponentContext container;

        public CommandParser(IEngine engine, IComponentContext container)
        {
            this.engine = engine;
            this.container = container;
        }

        public bool ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                this.engine.ConsoleManager.UserInteraction.AddAction("Command cannot be null or empty.");
                this.engine.Logger.GetLogger.Info("Client attempted to enter an empty/null command.");
                return false;
            }
            // Check for command access
            if (!this.engine.MenuManager.OptionsContainer.CurrentStageOptions(this.engine.PlayerProgress, true).Contains(commandAsString.Split()[0]))
            {
                this.engine.ConsoleManager.UserInteraction.AddAction($"You have no access to that command. ({commandAsString})");
                return false;
            }

            var command = this.engine.CommandParser.GetCommand(commandAsString);
            var parameters = this.engine.CommandParser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.engine.ConsoleManager.UserInteraction.AddAction(executionResult);

            return true;
        }

       /// <summary>
       /// Return ICommand - the command 
       /// </summary>
        public ICommand GetCommand(string fullCommand)
        {
            return this.container.ResolveNamed<ICommand>(fullCommand.ToLower());
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();

            // Manually Removed, take caution
            //commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
                return new List<string>();

            return commandParts;
        }
    }
}