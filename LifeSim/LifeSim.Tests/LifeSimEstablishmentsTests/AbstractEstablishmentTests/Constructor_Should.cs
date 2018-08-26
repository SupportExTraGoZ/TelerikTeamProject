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
            string buildingName = "Harvard University";

            var mockEstablishment = new MockEstablishment(buildingName);

            Assert.IsInstanceOfType(mockEstablishment, typeof(MockEstablishment));
            Assert.IsNotNull(mockEstablishment);
        }

        [TestMethod]
        public void SetProperBuildingName_WhenTheObjectIsConstructed()
        {
            string buildingName = "Harvard University";

            var mockEstablishment = new MockEstablishment(buildingName);

            Assert.AreEqual(buildingName, mockEstablishment.BuildingName);
        }
    }
}
