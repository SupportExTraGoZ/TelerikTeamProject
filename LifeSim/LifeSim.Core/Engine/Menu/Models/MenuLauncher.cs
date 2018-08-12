using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Options.Contracts;

namespace LifeSim.Core.Engine.Menu.Models
{
    public class MenuLauncher : IMenuLauncher
    {
        private readonly IConsoleReader reader;
        private readonly IConsoleWriter writer;

        public MenuLauncher(IConsoleWriter writer, IConsoleReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void PrintMenu(PlayerProgress playerProgress, IOptionsContainer optionsContainer)
        {
            foreach (var elem in optionsContainer.CurrentStageOptions(playerProgress, false))
            {
                writer.WriteLine(elem);
            }
        }
    }
}