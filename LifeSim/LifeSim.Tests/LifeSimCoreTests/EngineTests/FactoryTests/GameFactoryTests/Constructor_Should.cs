using LifeSim.Core.Engine.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LifeSim.Core.Engine.Factories.Contracts;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.FactoryTests.GameFactoryTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectArgumentsArePassed()
        {
            var mockPlayerFactory = new Mock<IPlayerFactory>();
            var mockJobFactory = new Mock<IJobFactory>();
            var mockEducationalInstituteFactory = new Mock<IEducationalInstituteFactory>();

            var factory = new GameFactory(mockPlayerFactory.Object, 
                mockJobFactory.Object, mockEducationalInstituteFactory.Object);

            Assert.IsNotNull(factory);
        }
    }
}
