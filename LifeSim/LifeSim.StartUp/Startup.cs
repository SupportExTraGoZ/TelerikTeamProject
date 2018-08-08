using LifeSim.Core.Engine.Core.Models;

namespace LifeSim.Startup
{
    /// <summary>
    ///     Console Client start point of "Life Simulator"
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     The entry point of the program, where the program control starts and ends.
        /// </summary>
        public static void Main()
        {
            //Console.WriteLine("LifeSim is still under development!");

            var firstInstance = Engine.Instance;
            firstInstance.Start();
        }
    }
}