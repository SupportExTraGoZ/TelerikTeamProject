using System;
using LifeSim.Establishments.Job;
using LifeSim.Establishments.Job.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LifeSim.Tests.LifeSimEstablishmentsTests.JobTests
{
    [TestClass]
    public class MonthlySalaryGetter_Should
    {
        [TestMethod]
        public void ReturnEqualObject_MonthlySalary()
        {
            ProfessionType profession = ProfessionType.SoftwareEngineer;
            int monthlySalary = 3000;
            int workHoursPerDay = 8;
            DateTime startDate = new DateTime(2018, 10, 1);

            var job = new Job(profession, monthlySalary, workHoursPerDay, startDate);

            var result = job.MonthlySalary;

            Assert.AreEqual(monthlySalary, result);
        }
    }
}
