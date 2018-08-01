using LifeSim.Establishments.Education.Contracts;
using LifeSim.Establishments.Education.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Education
{
    public abstract class EducationalInstitute : IEducationalInstitute
    {
        public string Name { get; }

        protected EducationalInstitute(string name)
        {
            this.Name = name;
        }

        public EducationType EducationType { get; set; }
    }
}
