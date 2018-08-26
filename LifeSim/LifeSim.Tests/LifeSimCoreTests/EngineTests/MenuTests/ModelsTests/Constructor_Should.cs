using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.Engine.Menu.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.MenuTests.ModelsTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParametersArePassed()
        {
            var writerMock = new Mock<IConsoleWriter>();
            var readerMock = new Mock<IConsoleReader>();

            var menuLauncher = new MenuLauncher(writerMock.Object, readerMock.Object);

            Assert.IsInstanceOfType(menuLauncher, typeof(MenuLauncher));
        }
    }
}