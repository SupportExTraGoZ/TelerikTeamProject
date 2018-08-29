using System;
using LifeSim.Establishments.Job.Enums;

namespace LifeSim.Establishments.Job.Contracts
{
    public interface IJob
    {
        int MonthlySalary { get; set; }

        int WorkHoursPerDay { get; set; }

        ProfessionType Profession { get; set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }
    }
}