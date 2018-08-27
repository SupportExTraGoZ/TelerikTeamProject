using System;
using LifeSim.Establishments.Job.Enums;
using LifeSim.Establishments.Job.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LifeSim.Tests.LifeSimEstablishmentsTests.JobTests
{
    [TestClass]
    public class ProfessionGetter_Should
    {
        [TestMethod]
        public void ReturnEqualObject_Profession()
        {
            var profession = ProfessionType.SoftwareEngineer;
            var monthlySalary = 3000;
            var workHoursPerDay = 8;
            var startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            var result = job.Profession;

            Assert.AreEqual(profession, result);
        }
    }
}