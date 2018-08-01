using LifeSim.Core.CLI.Module.ConsoleUsings;
using LifeSim.Core.CLI.Module.ConsoleUsings.Functions;
using LifeSim.Core.Engine.Menu;

namespace LifeSim.Core.Engine.Core
{
    public class Engine
    {
        //THIS CONST WILL BE MOVED TO OTHER PLACE
        private const string START_MENU_PATH = "startMenu.txt";

        // HM ABOUT THIS???
        private static readonly Engine engineInstance;

        private readonly IConsoleUsageProvider writer;
        private readonly IConsoleUsageProvider reader;
        private readonly IMenuLauncher menuServices;

        private Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();

            //this.menuServices = new MenuLauncher(this.writer, this.reader);
            this.menuServices.DisplayContent(START_MENU_PATH);
        }

        public static Engine Instance
        {
            get
            {
                if (engineInstance == null)
                {
                    return new Engine();
                }

                return engineInstance;
            }
        }

        public void Start()
        {

        }

    }
}
