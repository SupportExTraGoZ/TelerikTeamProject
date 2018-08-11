using LifeSim.Establishments.Education.HighSchool.Contract;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LifeSim.Establishments.Education.HighSchool
{
    public class HighSchool : EducationalInstitute, IHighSchool
    {
        private IList<string> highSchoolNames;

        public HighSchool(string name, int startYear, int graduateYear) : base(startYear, graduateYear)
        {
            EducationType = Enum.EducationType.HighSchool;

            highSchoolNames = new List<string>()
            {
               "BASIS Scottsdale",
               "BASIS Tucson North",
               "BASIS Oro Valley",
               "School for the Talented and Gifted",
               "BASIS Peoria",
               "Thomas Jefferson High School for Science and Technology",
               "BASIS Chandler",
               "Carnegie Vanguard High School",
               "School of Science and Engineering",
                "Pacific Collegiate Charter"
            };


            //Check if the given name exist in our data-base
            if (!highSchoolNames.Contains(name))
            {
                throw new ArgumentException("Name doesn't exist!");
            }

            base.BuildingName = name;

        }

        public IList<string> HighSchoolNames
        {
            get => new List<string>(highSchoolNames);
        }
    }
}