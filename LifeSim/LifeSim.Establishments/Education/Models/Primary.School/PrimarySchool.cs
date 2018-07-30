using LifeSim.Establishments.Education.Enum;
using LifeSim.Establishments.Education.Primary.School.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Education.Primary.School
{
    public class PrimarySchool : EducationalInstitute, IPrimarySchool
    {

        public PrimarySchool(string name) :base(name)
        {

        }
        
    }
}
