using LifeSim.Establishments.Education.University.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Education.University
{
    public class University : EducationalInstitute, IUniversity
    {
        public University(string name):base(name)
        {

        }
    }
}
