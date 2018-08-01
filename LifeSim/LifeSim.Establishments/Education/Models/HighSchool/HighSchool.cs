using LifeSim.Establishments.Education.HighSchool.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Education.HighSchool
{
    public class HighSchool : EducationalInstitute, IHighSchool
    {
        public HighSchool(string name) : base(name)
        {

        }
    }
}
