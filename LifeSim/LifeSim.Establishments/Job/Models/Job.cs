using System;
using LifeSim.Establishments.Job.Enums;

namespace LifeSim.Establishments.Job
{
    public class Job : IJob
    {
        public Job(ProfessionType profession, int monthlySalary, int workHoursPerDay, DateTime startDate)
        {
            Profession = profession;
            MonthlySalary = monthlySalary;
            WorkHoursPerDay = workHoursPerDay;
            StartDate = startDate;
        }

        public int MonthlySalary { get; set; }

        public int WorkHoursPerDay { get; set; }

        public ProfessionType Profession { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}