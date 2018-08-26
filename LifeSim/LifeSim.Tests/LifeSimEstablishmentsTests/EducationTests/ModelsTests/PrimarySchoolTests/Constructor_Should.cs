using LifeSim.Establishments.Education.PrimarySchool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.EducationTests.ModelsTests.PrimarySchoolTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParamatersArePassed()
        {
            string name = "St. Martin Elementary";
            int startYear = 2018;

            var primarySchool = new PrimarySchool(name, startYear);

            Assert.IsInstanceOfType(primarySchool, typeof(PrimarySchool));
            Assert.IsNotNull(primarySchool);
        }

        [TestMethod]
        public void SetProperName_WhenTheObjectIsConstructed()
        {
            string name = "St. Martin Elementary";
            int startYear = 2018;

            var primarySchool = new PrimarySchool(name, startYear);

            Assert.AreEqual(name, primarySchool.BuildingName);
        }

        [TestMethod]
        public void SetProperStartYear_WhenTheObjectIsConstructed()
        {
            string name = "St. Martin Elementary";
            int startYear = 2018;

            var primarySchool = new PrimarySchool(name, startYear);

            Assert.AreEqual(startYear, primarySchool.StartYear);
        }
    }
}
