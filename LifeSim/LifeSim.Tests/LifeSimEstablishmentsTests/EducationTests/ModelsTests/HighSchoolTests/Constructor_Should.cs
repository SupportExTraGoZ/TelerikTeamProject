using LifeSim.Establishments.Education.Models.HighSchool.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.EducationTests.ModelsTests.HighSchoolTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParamatersArePassed()
        {
            var name = "Thomas Jefferson";
            var startYear = 2018;

            var highSchool = new HighSchool(name, startYear);

            Assert.IsInstanceOfType(highSchool, typeof(HighSchool));
            Assert.IsNotNull(highSchool);
        }

        [TestMethod]
        public void SetProperName_WhenTheObjectIsConstructed()
        {
            var name = "Thomas Jefferson";
            var startYear = 2018;

            var highSchool = new HighSchool(name, startYear);

            Assert.AreEqual(name, highSchool.BuildingName);
        }

        [TestMethod]
        public void SetProperStartYear_WhenTheObjectIsConstructed()
        {
            var name = "Thomas Jefferson";
            var startYear = 2018;

            var highSchool = new HighSchool(name, startYear);

            Assert.AreEqual(startYear, highSchool.StartYear);
        }
    }
}