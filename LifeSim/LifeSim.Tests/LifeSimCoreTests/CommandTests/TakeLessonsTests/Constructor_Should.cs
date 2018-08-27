using LifeSim.Core.Engine.Commands.Actions.Lessons;
using LifeSim.Core.Engine.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.CommandTests.TakeLessonsTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParametersArePassed()
        {
            var engineMock = new Mock<IEngine>();

            var command = new TakeLessonsCommand(engineMock.Object);

            Assert.IsNotNull(command);
        }
    }
}