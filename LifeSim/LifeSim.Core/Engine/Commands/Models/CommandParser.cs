using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Exceptions.Models;
using LifeSim.Core.Engine.Core.Contracts;

namespace LifeSim.Core.Engine.Commands.Models
{
    public class CommandParser : IParser
    {
        private readonly IEngine engine;

        public CommandParser(IEngine engine)
        {
            this.engine = engine;
        }

        public bool ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                this.engine.UserInteraction.AddAction("Command cannot be null or empty.");
                this.engine.Logger.GetLogger.Info("Client attempted to enter an empty/null command.");
                return false;
            }
            // Check for command access
            if (!this.engine.OptionsContainer.CurrentStageOptions(this.engine.PlayerProgress, true).Contains(commandAsString.Split()[0]))
            {
                this.engine.UserInteraction.AddAction($"You have no access to that command. ({commandAsString})");
                return false;
            }

            var command = this.engine.Parser.ParseCommand(commandAsString);
            var parameters = this.engine.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.engine.UserInteraction.AddAction(executionResult);

            return true;
        }

        // Magic, do not touch!
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = FindCommand(commandName);
            var command = Activator.CreateInstance(commandTypeInfo, Core.Models.Engine.Instance) as ICommand;

            return command;
        }

        // Magic, do not touch!
        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();

            // Manually Removed, take caution
            //commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
                return new List<string>();

            return commandParts;
        }

        // Very magic, do not even think about touching!!!
        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower() == commandName.ToLower() + "command")
                .SingleOrDefault();

            if (commandTypeInfo == null)
                throw new CustomException("The passed command is not found!");

            return commandTypeInfo;
        }
    }
}