﻿using LifeSim.Establishments.Education.University.Contracts;

namespace LifeSim.Establishments.Education.University
{
    public class University : EducationalInstitute, IUniversity
    {
        public University(string name, int startYear, int graduateYear) : base(name, startYear, graduateYear)
        {
            EducationType = Enum.EducationType.University;

            universityNames = new List<string>()
            {
              "Princeton",
              "Harvard",
              "University of Chicago",
              "Yale University",
              "Columbia University",
              "Massachusetts Institute of Technology",
              "Stanford",
              "University of Pennsylvania",
              "Duke University",
              "Georgetown University"
            };

            //Check if the given name exist in our data-base
            if (!universityNames.Contains(name))
            {
                throw new ArgumentException("Name doesn't exist!");
            }

            base.BuildingName = name;
        }
    }
}