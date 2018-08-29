using LifeSim.Tests.LifeSimEstablishmentsTests.AbstractEstablishmentTests.MockAbstractEstablishment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.AbstractEstablishmentTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParametersArePassed()
        {
            var buildingName = "Harvard University";

            var mockEstablishment = new MockEstablishment(buildingName);

            Assert.IsNotNull(mockEstablishment);
        }

        [TestMethod]
        public void SetProperBuildingName_WhenTheObjectIsConstructed()
        {
            var buildingName = "Harvard University";

            var mockEstablishment = new MockEstablishment(buildingName);

            Assert.AreEqual(buildingName, mockEstablishment.BuildingName);
        }
    }
}