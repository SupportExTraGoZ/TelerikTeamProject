using LifeSim.Core.Engine.Factories;
using LifeSim.Core.Engine.Factories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.FactoryTests.GameFactoryTests
{
    [TestClass]
    public class JobFactoryGetter_Should
    {
        [TestMethod]
        public void ReturnTheSameObject_When_IsCalled()
        {
            var mockPlayerFactory = new Mock<IPlayerFactory>();
            var mockJobFactory = new Mock<IJobFactory>();
            var mockEducationalInstituteFactory = new Mock<IEducationalInstituteFactory>();

            var factory = new GameFactory(mockPlayerFactory.Object,
                mockJobFactory.Object, mockEducationalInstituteFactory.Object);

            Assert.AreSame(mockJobFactory.Object, factory.JobFactory);
        }
    }
}
