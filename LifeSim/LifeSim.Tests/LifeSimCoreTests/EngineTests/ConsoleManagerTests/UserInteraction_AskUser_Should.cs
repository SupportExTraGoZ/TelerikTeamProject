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
   public class UserInteraction_AskUser_Should
    {
        [TestMethod]
        public void ReturnMessage_WhenIsNotInTheSameLine()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            consoleWriterMock.Setup(w => w.WriteLine("not same"));

            var consoleReaderMock = new Mock<IConsoleReader>();
           
            var userInteraction = new UserInteraction(consoleWriterMock.Object, consoleReaderMock.Object);

            var askUser = userInteraction.AskUser("not same", false);

            consoleWriterMock.Verify(w => w.WriteLine("not same"));
        }

        [TestMethod]
        public void ReturnMessage_WhenIsOnTheSameTheSameLine()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            consoleWriterMock.Setup(w => w.Write("same"));

            var consoleReaderMock = new Mock<IConsoleReader>();

            var userInteraction = new UserInteraction(consoleWriterMock.Object, consoleReaderMock.Object);

            var askUser = userInteraction.AskUser("same", true);

            consoleWriterMock.Verify(w => w.Write("same"));
        }

        [TestMethod]
        public void Call_ReadLine()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
           
            var consoleReaderMock = new Mock<IConsoleReader>();
            consoleReaderMock.Setup(r => r.ReadLine());

            var userInteraction = new UserInteraction(consoleWriterMock.Object, consoleReaderMock.Object);

            var askUser = userInteraction.AskUser("same", true);

            consoleReaderMock.Verify(r => r.ReadLine(), Times.Once);
        }
    }
}
