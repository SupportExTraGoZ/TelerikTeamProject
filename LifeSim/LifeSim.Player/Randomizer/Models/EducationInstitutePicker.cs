using System;
using LifeSim.Player.Randomizer.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace LifeSim.Player.Randomizer.Models
{
    public class EducationInstitutePicker : IEducationInstitutePicker
    {
        private readonly Random GetRandom = new Random();

        public string PickPrimarySchool(bool successful = false)
        {
            var tempStorage = primarySchools.Keys.Where(x => primarySchools[x] == successful);
            return tempStorage.ElementAt(GetRandom.Next(0, tempStorage.Count() - 1));
        }

        public string PickHighSchool(bool successful = false)
        {
            var tempStorage = highSchools.Keys.Where(x => highSchools[x] == successful);
            return tempStorage.ElementAt(GetRandom.Next(0, tempStorage.Count() - 1));
        }

        public string PickUniversities(bool successful = false)
        {
            var tempStorage = universities.Keys.Where(x => universities[x] == successful);
            return tempStorage.ElementAt(GetRandom.Next(0, tempStorage.Count() - 1));
        }

        private readonly IDictionary<string, bool> primarySchools = new Dictionary<string, bool>
            {
                // bool = Is school prestigious or not
                {"John Ward", true},
                {"Edward Brooke-Charter", true},
                {"Neshkoro Elementary", false},
                {"Weyerhaeuser Elementary", true},
                {"Life School McKinney", false},
                {"St. Martin Elementary", false},
                {"Polaris at Albert Einstein", true}
            };

        private readonly IDictionary<string, bool> highSchools = new Dictionary<string, bool>
            {
                // bool = Is school prestigious or not
                {"John Ward", true},
                {"Edward Brooke-Charter", true},
                {"Neshkoro Elementary", false},
                {"Weyerhaeuser Elementary", true},
                {"Life School McKinney", false},
                {"St. Martin Elementary", false},
                {"Polaris at Albert Einstein", true}
            };

        private readonly IDictionary<string, bool> universities = new Dictionary<string, bool>
            {
                // bool = Is school prestigious or not
                {"John Ward", true},
                {"Edward Brooke-Charter", true},
                {"Neshkoro Elementary", false},
                {"Weyerhaeuser Elementary", true},
                {"Life School McKinney", false},
                {"St. Martin Elementary", false},
                {"Polaris at Albert Einstein", true}
            };
    }
}