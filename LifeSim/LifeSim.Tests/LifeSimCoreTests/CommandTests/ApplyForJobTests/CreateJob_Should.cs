using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Actions.Job;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Establishments.Job.Contracts;
using LifeSim.Establishments.Job.Enums;
using LifeSim.Player.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.CommandTests.ApplyForJobTests
{
    [TestClass]
    public class CreateJob_Should
    {
        [TestMethod]
        public void CreateJob_Should_GetCalled()
        {
            // Arrange
            var engineMock = new Mock<IEngine>();
            var playerMock = new Mock<IPlayer>();
            var jobMock = new Mock<IJob>();

            jobMock.SetupGet(x => x.Profession).Returns(ProfessionType.PoliceOfficer);
            playerMock.SetupGet(x => x.Job).Returns(jobMock.Object);
            engineMock.SetupGet(x => x.Player).Returns(playerMock.Object);

            var gameFactoryMock = new Mock<IGameFactory>();
            var jobFactoryMock = new Mock<IJobFactory>();

            gameFactoryMock.SetupGet(x => x.JobFactory).Returns(jobFactoryMock.Object);

            // Act
            var command = new ApplyForJobCommand(engineMock.Object, gameFactoryMock.Object)
            {
                Parameters = new List<string> { ProfessionType.PoliceOfficer.ToString() }
            };
            var commandExecute = command.Execute();

            // Assert
            jobFactoryMock.Verify(
                x => x.CreateJob(ProfessionType.PoliceOfficer, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>()),
                Times.Once);
        }
    }
}