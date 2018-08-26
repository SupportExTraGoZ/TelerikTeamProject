using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Models;
using LifeSim.Player.Options.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.MenuTests.ManagerTests.ModelsTests
{
    [TestClass]
    public class OptionContainerGetter_Should
    {
        [TestMethod]
        public void ReturTheSameObject_OptionContainer()
        {
            var menuLauncherMock = new Mock<IMenuLauncher>();
            var optionContainerMock = new Mock<IOptionsContainer>();

            var menuManager = new MenuManager(menuLauncherMock.Object, optionContainerMock.Object);

            Assert.AreSame(optionContainerMock.Object, menuManager.OptionsContainer);
        }
    }
}