using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.ConsoleManagerTests
{
    [TestClass]
   public class UserInteractionConstructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParametersArePassed()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var consoleReaderMock = new Mock<IConsoleReader>();

            var userInteraction = new UserInteraction(consoleWriterMock.Object, consoleReaderMock.Object);

            Assert.IsNotNull(userInteraction);
        }
    }
}
