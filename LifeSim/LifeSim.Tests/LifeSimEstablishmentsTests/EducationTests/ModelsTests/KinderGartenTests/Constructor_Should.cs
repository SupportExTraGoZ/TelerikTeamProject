using LifeSim.Establishments.Education.Models.KinderGarten.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.EducationTests.ModelsTests.KinderGartenTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParamatersArePassed()
        {
            var name = "Collegiate Garden";
            var startYear = 2018;

            var kinderGarten = new KinderGarten(name, startYear);

            Assert.IsInstanceOfType(kinderGarten, typeof(KinderGarten));
            Assert.IsNotNull(kinderGarten);
        }

        [TestMethod]
        public void SetProperName_WhenTheObjectIsConstructed()
        {
            var name = "Collegiate Garden";
            var startYear = 2018;

            var kinderGarten = new KinderGarten(name, startYear);

            Assert.AreEqual(name, kinderGarten.BuildingName);
        }

        [TestMethod]
        public void SetProperStartYear_WhenTheObjectIsConstructed()
        {
            var name = "Collegiate Garden";
            var startYear = 2018;

            var kinderGarten = new KinderGarten(name, startYear);

            Assert.AreEqual(startYear, kinderGarten.StartYear);
        }
    }
}