using LifeSim.Core.Engine.Commands.Actions.Kindergarten;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Factories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.CommandTests.GoToKinderGartenTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParametersArePassed()
        {
            var engineMock = new Mock<IEngine>();
            var gameFactoryMock = new Mock<IGameFactory>();

            var command = new GoToKinderGartenCommand(engineMock.Object, gameFactoryMock.Object);

            Assert.IsNotNull(command);
        }
    }
}