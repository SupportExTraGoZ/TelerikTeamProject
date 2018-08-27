using LifeSim.Establishments.Job;
using LifeSim.Establishments.Job.Enums;
using System;

namespace LifeSim.Core.Engine.Factories.Contracts
{
    public interface IJobFactory
    {
        IJob CreateJob(ProfessionType profession, int monthlySalary, int workHoursPerDay, DateTime startDate);
    }
}
