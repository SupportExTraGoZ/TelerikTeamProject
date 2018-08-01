namespace LifeSim.Core.Engine.Core
{
    public class Engine
    {
        private static readonly Engine engineInstance;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        

        private Engine()
        {

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

    }
}
