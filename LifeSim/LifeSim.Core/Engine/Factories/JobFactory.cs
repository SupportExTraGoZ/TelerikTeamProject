using System;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Establishments.Job;
using LifeSim.Establishments.Job.Contracts;
using LifeSim.Establishments.Job.Enums;
using LifeSim.Establishments.Job.Models;

namespace LifeSim.Core.Engine.Factories
{
    public class JobFactory : IJobFactory
    {
        public IJob CreateJob(ProfessionType profession, int monthlySalary, int workHoursPerDay, DateTime startDate)
        {
            return new Job(profession, monthlySalary, workHoursPerDay, startDate);
        }
    }
}