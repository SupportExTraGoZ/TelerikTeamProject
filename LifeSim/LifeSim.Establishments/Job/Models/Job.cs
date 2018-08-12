using System;
using System.Collections.Generic;
using LifeSim.Establishments.AbstractEstablishment.Models;
using LifeSim.Establishments.Job.Companies;
using LifeSim.Establishments.Job.Enums;

namespace LifeSim.Establishments.Job
{
    public class Job : Establishment, IJob
    {
        private ICompany company;
        private double monthSalary;
        private int workHoursPerDay;
        private DateTime startDate;
        private DateTime endDate = new DateTime(0, 0, 0);

        public Job(ProfessionType profession, string companyName, double monthSalary, int workHoursPerDay,DateTime startDate,DateTime endDate)
            :base()
        {
            Profession = profession;
            company = new Company(companyName);
            MonthSalary = monthSalary;
            WorkHoursPerDay = workHoursPerDay;
            StartDate = startDate;
            EndDate = endDate;
        }

        public double MonthSalary
        {
            get => monthSalary;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Month salary cannot be negative.");

                monthSalary = value;
            } 
        }

        public int WorkHoursPerDay
        {
            get => workHoursPerDay;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Hours of work per day cannot be negative.");

                workHoursPerDay = value;
            }
        }

        public ProfessionType Profession { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}