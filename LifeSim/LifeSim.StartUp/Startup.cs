using Autofac;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.IoContainer.CLI.InjectionConfig;

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
            var containerConfig = new AutofacConfig();

            var container = containerConfig.Build();

            var engine = container.Resolve<IEngine>();
            engine.Start();
        }
    }
}