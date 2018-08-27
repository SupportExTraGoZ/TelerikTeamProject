using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Models;
using LifeSim.Player.Options.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LifeSim.Tests.LifeSimCoreTests.EngineTests.MenuTests.ManagerTests.ModelsTests
{
    [TestClass]
    public class MenuLauncherGetter_Should
    {
        [TestMethod]
        public void ReturnTheSameObject_MenuLauncher()
        {
            var menuLauncherMock = new Mock<IMenuLauncher>();
            var optionContainerMock = new Mock<IOptionsContainer>();

            var menuManager = new MenuManager(menuLauncherMock.Object, optionContainerMock.Object);

            Assert.IsNotNull(menuManager.MenuLauncher);
        }
    }
}