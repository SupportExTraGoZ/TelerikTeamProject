using LifeSim.Establishments.Education.Enum;
using LifeSim.Establishments.Education.PrimarySchool.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Education.PrimarySchool
{
    public class PrimarySchool : EducationalInstitute, IPrimarySchool
    {

        public PrimarySchool(string name) : base(name)
        {

        }

    }
}