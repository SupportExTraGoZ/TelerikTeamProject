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

        public Job(ProfessionType profession, string companyName, double monthlySalary, int workHoursPerDay, DateTime startDate, DateTime endDate)
            : base(companyName)
        {
            Profession = profession;
            // This will go - be fixed/majorly improved
            company = new Company(companyName);
            MonthlySalary = monthlySalary;
            WorkHoursPerDay = workHoursPerDay;
            StartDate = startDate;
            EndDate = endDate;
        }

        public double MonthlySalary { get; set; }

        public int WorkHoursPerDay { get; set; }

        public ProfessionType Profession { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}