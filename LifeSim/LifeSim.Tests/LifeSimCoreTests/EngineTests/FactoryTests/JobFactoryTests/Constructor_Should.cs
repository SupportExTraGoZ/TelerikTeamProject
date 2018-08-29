using LifeSim.Core.Engine.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.FactoryTests.JobFactoryTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectArgumentsArePassed()
        {
            var factory = new JobFactory();

            Assert.IsNotNull(factory);
        }
    }
}
