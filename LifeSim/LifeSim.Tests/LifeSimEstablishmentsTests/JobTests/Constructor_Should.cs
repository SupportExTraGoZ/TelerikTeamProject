using System;
using LifeSim.Establishments.Job;
using LifeSim.Establishments.Job.Enums;
using LifeSim.Establishments.Job.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.JobTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParametersArePassed()
        {
            var profession = ProfessionType.SoftwareEngineer;
            var monthlySalary = 3000;
            var workHoursPerDay = 8;
            var startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.IsNotNull(job);
        }

        [TestMethod]
        public void SetProperProfession_WhenTheObjectIsConstructed()
        {
            var profession = ProfessionType.SoftwareEngineer;
            var monthlySalary = 3000;
            var workHoursPerDay = 8;
            var startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.AreEqual(profession, job.Profession);
        }

        [TestMethod]
        public void SetProperMonthlySalary_WhenTheObjectIsConstructed()
        {
            var profession = ProfessionType.SoftwareEngineer;
            var monthlySalary = 3000;
            var workHoursPerDay = 8;
            var startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.AreEqual(monthlySalary, job.MonthlySalary);
        }

        [TestMethod]
        public void SetProperWorkHoursPerDay_WhenTheObjectIsConstructed()
        {
            var profession = ProfessionType.SoftwareEngineer;
            var monthlySalary = 3000;
            var workHoursPerDay = 8;
            var startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.AreEqual(workHoursPerDay, job.WorkHoursPerDay);
        }

        [TestMethod]
        public void SetProperStartDate_WhenTheObjectIsConstructed()
        {
            var profession = ProfessionType.SoftwareEngineer;
            var monthlySalary = 3000;
            var workHoursPerDay = 8;
            var startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.AreEqual(startDate, job.StartDate);
        }
    }
}