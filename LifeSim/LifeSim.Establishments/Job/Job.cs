using LifeSim.Establishments.Job.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using LifeSim.Establishments.Job.Companies;

namespace LifeSim.Establishments.Job
{
    public class Job : IJob
    {
        private Company company;
        private int monthSalary;
        private int workHoursPerDay;

        public Job(ProfessionType profession,string companyName, int monthSalary,int workHoursPerDay)
        {
            Profession = profession;
            company = new Company(companyName);
            MonthSalary = monthSalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public double MonthSalary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int WorkHoursPerDay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ProfessionType Profession { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
