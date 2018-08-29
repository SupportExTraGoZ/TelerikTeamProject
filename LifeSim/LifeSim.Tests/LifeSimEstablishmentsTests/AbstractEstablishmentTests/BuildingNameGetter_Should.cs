using LifeSim.Tests.LifeSimEstablishmentsTests.AbstractEstablishmentTests.MockAbstractEstablishment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.AbstractEstablishmentTests
{
    [TestClass]
    public class BuildingNameGetter_Should
    {
        [TestMethod]
        public void ReturnTheProperValue_WhenGetMethodIsCalled()
        {
            var buildingName = "Harvard University";
            var mockEstablishment = new MockEstablishment(buildingName);

            var result = mockEstablishment.BuildingName;

            Assert.AreSame(buildingName, result);
        }
    }
}