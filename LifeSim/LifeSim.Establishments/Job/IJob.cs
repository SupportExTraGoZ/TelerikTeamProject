using LifeSim.Establishments.Job.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Job
{
    public interface IJob
    {
        double MonthSalary { get; set; }

        int WorkHoursPerDay { get; set; }

        ProfessionType Profession { get; set; }
    }
}
