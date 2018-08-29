using System;
using LifeSim.Establishments.Job.Contracts;
using LifeSim.Establishments.Job.Enums;

namespace LifeSim.Core.Engine.Factories.Contracts
{
    public interface IJobFactory
    {
        IJob CreateJob(ProfessionType profession, int monthlySalary, int workHoursPerDay, DateTime startDate);
    }
}