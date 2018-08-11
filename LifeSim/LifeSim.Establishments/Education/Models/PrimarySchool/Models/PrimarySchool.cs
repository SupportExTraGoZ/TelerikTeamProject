using LifeSim.Establishments.Education.PrimarySchool.Contracts;
using System.Collections.Generic;
using System;

namespace LifeSim.Establishments.Education.PrimarySchool
{
    public class PrimarySchool : EducationalInstitute, IPrimarySchool
    {
        public PrimarySchool(string name, int startYear) : base(name, startYear)
        {
            this.Name = name;
            this.StartYear = startYear;
        }
    }
}