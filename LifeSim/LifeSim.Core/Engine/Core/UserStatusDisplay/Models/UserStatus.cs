using System.Collections.Generic;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Player.Contracts;

namespace LifeSim.Core.Engine.Core.UserStatusDisplay.Models
{
    public class UserStatus : IUserStatus
    {
        private readonly IConsoleWriter writer;

        public UserStatus(IConsoleWriter writer)
        {
            this.writer = writer;
        }

        public void WriteStatus(IPlayer player)
        {
            writer.WriteLine($"{new string('=', 30)} Stats {new string('=', 30)}");
            writer.WriteLine(
                $"Father: {player.Father.FirstName} {player.Father.LastName} | Age: {player.Father.Age} | Birthplace: {player.Father.GetBirthplace()}");
            writer.WriteLine(
                $"Mother: {player.Mother.FirstName} {player.Mother.LastName} | Age: {player.Mother.Age} | Birthplace: {player.Mother.GetBirthplace()}");
            writer.WriteLine(
                $"You: {player.FirstName} {player.LastName} | Age: {player.Age} | Gender: {player.Gender} | Birthplace: {player.GetBirthplace()}");
            writer.WriteLine($"{new string('=', 67)}");
        }

        public void WriteActionLog(List<string> actions, int count)
        {
            writer.WriteLine($"{new string('=', 30)} Action History {new string('=', 21)}");
            writer.WriteLines(actions, count);
            writer.WriteLine($"{new string('=', 67)}");
        }
    }
}