using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Exceptions.Models;

namespace LifeSim.Core.Engine.Commands.Models
{
    public class CommandParser : IParser
    {
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