using LifeSim.Establishments.Job;
using LifeSim.Establishments.Job.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.JobTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_When_CorrectParametersArePassed()
        {
            ProfessionType profession = ProfessionType.SoftwareEngineer;
            int monthlySalary = 3000;
            int workHoursPerDay = 8;
            DateTime startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.IsInstanceOfType(job, typeof(Job));
            Assert.IsNotNull(job);
        }

        [TestMethod]
        public void SetProperProfession_WhenTheObjectIsConstructed()
        {
            ProfessionType profession = ProfessionType.SoftwareEngineer;
            int monthlySalary = 3000;
            int workHoursPerDay = 8;
            DateTime startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.AreEqual(profession, job.Profession);
        }

        [TestMethod]
        public void SetProperMonthlySalary_WhenTheObjectIsConstructed()
        {
            ProfessionType profession = ProfessionType.SoftwareEngineer;
            int monthlySalary = 3000;
            int workHoursPerDay = 8;
            DateTime startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.AreEqual(monthlySalary, job.MonthlySalary);
        }

        [TestMethod]
        public void SetProperWorkHoursPerDay_WhenTheObjectIsConstructed()
        {
            ProfessionType profession = ProfessionType.SoftwareEngineer;
            int monthlySalary = 3000;
            int workHoursPerDay = 8;
            DateTime startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.AreEqual(workHoursPerDay, job.WorkHoursPerDay);
        }

        [TestMethod]
        public void SetProperStartDate_WhenTheObjectIsConstructed()
        {
            ProfessionType profession = ProfessionType.SoftwareEngineer;
            int monthlySalary = 3000;
            int workHoursPerDay = 8;
            DateTime startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            Assert.AreEqual(startDate, job.StartDate);
        }

    }
}
