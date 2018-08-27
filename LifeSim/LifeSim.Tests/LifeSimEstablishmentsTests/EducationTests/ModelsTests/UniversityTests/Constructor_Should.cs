﻿using LifeSim.Establishments.Education.Models.University.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.EducationTests.ModelsTests.UniversityTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParamatersArePassed()
        {
            var name = "Stanford University";
            var startYear = 2018;

            var university = new University(name, startYear);

            Assert.IsInstanceOfType(university, typeof(University));
            Assert.IsNotNull(university);
        }

        [TestMethod]
        public void SetProperName_WhenTheObjectIsConstructed()
        {
            var name = "Stanford University";
            var startYear = 2018;

            var university = new University(name, startYear);

            Assert.AreEqual(name, university.BuildingName);
        }

        [TestMethod]
        public void SetProperStartYear_WhenTheObjectIsConstructed()
        {
            var name = "Stanford University";
            var startYear = 2018;

            var university = new University(name, startYear);

            Assert.AreEqual(startYear, university.StartYear);
        }
    }
}