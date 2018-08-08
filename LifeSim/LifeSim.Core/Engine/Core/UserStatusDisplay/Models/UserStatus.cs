using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Player.Contracts;
using System.Collections.Generic;

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
            this.writer.WriteLine($"{new string('=', 30)} Stats {new string('=', 30)}");
            this.writer.WriteLine($"Father: {player.Father.FirstName} {player.Father.LastName} | Age: {player.Father.Age} | Birthplace: {player.Father.GetBirthplace()}");
            this.writer.WriteLine($"Mother: {player.Mother.FirstName} {player.Mother.LastName} | Age: {player.Mother.Age} | Birthplace: {player.Mother.GetBirthplace()}");
            this.writer.WriteLine(
                $"You: {player.FirstName} {player.LastName} | Age: {player.Age} | Gender: {player.Gender} | Birthplace: {player.GetBirthplace()}");
            this.writer.WriteLine($"{new string('=', 67)}");
        }

        public void WriteActionLog(List<string> actions, int count)
        {
            this.writer.WriteLine($"{new string('=', 30)} Action History {new string('=', 30)}");
            this.writer.WriteLines(actions, count);
            this.writer.WriteLine($"{new string('=', 67)}");
        }
    }
}
