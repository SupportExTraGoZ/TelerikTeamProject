using LifeSim.Core.Engine.Commands.Actions.General;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Player.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.CommandTests.AgeUpTests
{
    [TestClass]
    public class AgeUp_Should
    {
        [TestMethod]
        public void AgeUp_Should_IncrementAge()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var playerMock = new Mock<IPlayer>();
            var fatherMock = new Mock<IParent>();
            var motherMock = new Mock<IParent>();
            var tempAge = 1;
            playerMock.SetupSet(x => x.Age = It.IsAny<int>()).Callback<int>(x => tempAge = x);
            playerMock.SetupGet(x => x.Age).Returns(tempAge);
            playerMock.SetupGet(x => x.Father).Returns(fatherMock.Object);
            playerMock.SetupGet(x => x.Mother).Returns(motherMock.Object);
            engineMock.SetupGet(x => x.Player).Returns(playerMock.Object);

            // Act
            var command = new AgeUpCommand(engineMock.Object);
            var commandExecute = command.Execute();

            // Assert
            Assert.IsTrue(tempAge == 2);
        }
    }
}