using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts.Utilities;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.ConsoleManagerTests
{
    [TestClass]
    public class QuestionActionGetter_Should
    {
        [TestMethod]
        public void ReturnTheSameObject_QuestionAction()
        {
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var consoleReaderMock = new Mock<IConsoleReader>();
            var consoleCleanerMock = new Mock<IConsoleCleaner>();
            var userInteractionMock = new Mock<IUserInteraction>();
            var questionActionMock = new Mock<IQuestionAction>();

            var consoleManager = new ConsoleManager(consoleWriterMock.Object, consoleReaderMock.Object,
                consoleCleanerMock.Object, userInteractionMock.Object, questionActionMock.Object);

            Assert.IsNotNull(consoleManager.QuestionAction);
        }
    }
}