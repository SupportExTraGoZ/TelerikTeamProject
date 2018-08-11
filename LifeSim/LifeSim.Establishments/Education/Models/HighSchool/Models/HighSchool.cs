﻿using LifeSim.Establishments.Education.HighSchool.Contracts;

namespace LifeSim.Establishments.Education.HighSchool
{
    public class HighSchool : EducationalInstitute, IHighSchool
    {
        public HighSchool(string name, int startYear, int graduateYear) : base(name, startYear, graduateYear)
        {

        }
    }
}