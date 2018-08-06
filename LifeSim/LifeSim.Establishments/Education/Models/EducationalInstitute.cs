using System;
using LifeSim.Establishments.Education.Contracts;
using LifeSim.Establishments.Education.Enum;

namespace LifeSim.Establishments.Education
{
    public abstract class EducationalInstitute : IEducationalInstitute
    {
        private int startYear;
        private int graduateYear;

        protected EducationalInstitute(string name, int startYear, int graduateYear)
        {
            Name = name;
            StartYear = startYear;
            GraduateYear = graduateYear;
        }

        public string Name { get; }

        public EducationType EducationType { get; set; }
        public int StartYear
        {
            get => startYear;
            set
            {
                if (value < 1900 || value > 2018) throw new ArgumentOutOfRangeException("Start year must be between 1900 and 2018.");

                startYear = value; 
            }
        }

        public int GraduateYear
        {
            get => graduateYear;
            set
            {
                if (value < 1900 || value > 2030) throw new ArgumentOutOfRangeException("Graduate year must be between 1900 and 2030.");

                graduateYear = value;
            }

        }
    }
}