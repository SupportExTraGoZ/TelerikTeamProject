using LifeSim.Establishments.Education.PrimarySchool.Contract;
using System.Collections.Generic;
using System;

namespace LifeSim.Establishments.Education.PrimarySchool
{
    public class PrimarySchool : EducationalInstitute, IPrimarySchool
    {
        private IList<string> names;

        public PrimarySchool(string name, int startYear, int graduateYear) : base(startYear, graduateYear)
        {
            names = new List<string>();

            AddNames();

            //Check if the given name exist in our data-base
            if (!names.Contains(name))
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

        public IList<string> Names
        {
            get => new List<string>(names);
        }
        

    }
}