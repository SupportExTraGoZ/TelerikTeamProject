using System;
using LifeSim.Establishments.Education.Contracts;
using LifeSim.Establishments.Education.Enum;

namespace LifeSim.Establishments.Education
{
    public abstract class EducationalInstitute : IEducationalInstitute
    {
        public EducationalInstitute(string name, int startYear)
        {
            Name = name;
            StartYear = startYear;
        }

        public string Name { get; set; }

        public EducationType EducationType { get; set; }

        public int StartYear { get; set; }
        public int GraduateYear { get; set; }
    }
}