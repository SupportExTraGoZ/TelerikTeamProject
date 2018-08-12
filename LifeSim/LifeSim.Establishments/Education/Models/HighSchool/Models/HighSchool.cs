using System.Collections.Generic;
using LifeSim.Establishments.Education.HighSchool.Contracts;

namespace LifeSim.Establishments.Education.HighSchool
{
    public class HighSchool : EducationalInstitute, IHighSchool
    {
        //private readonly IDictionary<string, bool> highSchools = new Dictionary<string, bool>
        //    {
        //        // bool = Is school prestigious or not
        //        {"John Ward", true},
        //        {"Edward Brooke-Charter", true},
        //        {"Neshkoro Elementary", false},
        //        {"Weyerhaeuser Elementary", true},
        //        {"Life School McKinney", false},
        //        {"St. Martin Elementary", false},
        //        {"Polaris at Albert Einstein", true}
        //    };

        public HighSchool(string name, int startYear) : base(name, startYear)
        {
            EducationType = Enum.EducationType.HighSchool;

            //Name = name;

            //this.StartYear = startYear; => No need of this? we give startYear to the base c-tor
        }

        /// <summary>
        /// Gets the primary schools.
        /// </summary>
        /// <value>bool = Is the school prestigious.</value>
        
        // we have highSchools in Educational Picker ?? why need them here ?
        //public IDictionary<string, bool> HighSchools
        //{
        //    get
        //    {
        //        return new Dictionary<string, bool>(highSchools);
        //    }
        //}
    }
}