﻿using LifeSim.Establishments.Job.Enums;
using System;

namespace LifeSim.Establishments.Job
{
    public interface IJob
    {
        double MonthSalary { get; set; }

        int WorkHoursPerDay { get; set; }

        ProfessionType Profession { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }
    }
}