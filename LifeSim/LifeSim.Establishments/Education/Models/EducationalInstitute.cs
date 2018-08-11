using System;
using LifeSim.Establishments.AbstractEstablishment.Models;
using LifeSim.Establishments.Education.Contracts;
using LifeSim.Establishments.Education.Enum;

namespace LifeSim.Establishments.Education
{
    public abstract class EducationalInstitute : Establishment, IEducationalInstitute
    {
        public EducationalInstitute(string name, int startYear, int graduateYear)
        {
            Name = name;
            StartYear = startYear;
            GraduateYear = graduateYear;
        }

        public string Name { get; set; }

        public EducationType EducationType { get; set; }

        public int StartYear { get; set; }
        public int GraduateYear { get; set; }
    }
}