using LifeSim.Establishments.Education.PrimarySchool.Contracts;
using System.Collections.Generic;
using System;

namespace LifeSim.Establishments.Education.PrimarySchool
{
    public class PrimarySchool : EducationalInstitute, IPrimarySchool
    {
        private IList<string> primarySchoolNames;

        public PrimarySchool(string name, int startYear, int graduateYear) : base(startYear, graduateYear)
        {
            EducationType = Enum.EducationType.PrimarySchool;

            primarySchoolNames = new List<string>()
            {
                "John Ward",
                "Edward Brooke-Charter",
                "Neshkoro Elementary",
                "Weyerhaeuser Elementary",
                "Life School McKinney",
                "Martin Elementary School",
                "Challenge Elementary",
                "Polaris at Ebert"
            };

            //Check if the given name exist in our data-base
            if (!primarySchoolNames.Contains(name))
            {
                throw new ArgumentException("Name doesn't exist!");
            }

            base.Name = name;
        }

        private void AddNames()
        {
            names.Add("John Ward");
            names.Add("Edward Brooke-Charter");
            names.Add("Neshkoro Elementary");
            names.Add("Weyerhaeuser Elementary");
            names.Add("Life School McKinney");
            names.Add("Martin Elementary School");
            names.Add("Challenge Elementary");
            names.Add("Polaris at Ebert");
        }
        
        public IList<string> PrimarySchoolNames
        {
            get => new List<string>(primarySchoolNames);
        }


    }
}