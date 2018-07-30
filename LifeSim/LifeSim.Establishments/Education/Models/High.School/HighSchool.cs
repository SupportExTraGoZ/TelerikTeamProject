using LifeSim.Establishments.Education.High.School.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Education.High.School
{
    public class HighSchool : EducationalInstitute , IHighSchool
    {
        public HighSchool(string name) : base(name)
        {

        }
    }
}
