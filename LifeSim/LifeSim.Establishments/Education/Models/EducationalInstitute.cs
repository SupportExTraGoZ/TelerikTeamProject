using System;
using LifeSim.Establishments.AbstractEstablishment.Models;
using LifeSim.Establishments.Education.Contracts;

namespace LifeSim.Establishments.Education
{
    public abstract class EducationalInstitute : Establishment, IEducationalInstitute
    {
        public EducationalInstitute(string name, int startYear) : base(name)
        {
            StartYear = startYear;
        }

        public string Name
        {
            get => base.BuildingName;
            set => base.BuildingName = value;

        }

        public int StartYear { get; set; }
        public int GraduateYear { get; set; }
    }
}