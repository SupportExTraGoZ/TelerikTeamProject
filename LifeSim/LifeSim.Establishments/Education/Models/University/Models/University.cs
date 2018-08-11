using System;
using System.Collections.Generic;
using LifeSim.Establishments.Education.University.Contract;

namespace LifeSim.Establishments.Education.University
{
    public class University : EducationalInstitute, IUniversity
    {
        private IList<string> universityNames;

        public University(string name, int startYear, int graduateYear) : base(startYear,graduateYear)
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

        public IList<string> UniverityNames
        {
            get => new List<string>(universityNames);
        }
    } 
}