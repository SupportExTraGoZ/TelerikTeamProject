﻿using System;
using System.Collections.Generic;
using System.Linq;
using LifeSim.Player.Randomizer.Contracts.Generators;

namespace LifeSim.Player.Randomizer.Models.Generators
{
    public class EducationInstitutePicker : IEducationInstitutePicker
    {
        private readonly Random GetRandom = new Random();

        private readonly IDictionary<string, bool> highSchools = new Dictionary<string, bool>
        {
            // bool = Is school prestigious or not
            {"Scottsdale", true},
            {"Chandler", true},
            {"Oro Valley", false},
            {"Tucson North", true},
            {"Flagstaff", false},
            {"Meridian School", false},
            {"Thomas Jefferson", true}
        };

        private readonly IList<string> kinderGartens = new List<string>
        {
            "Germantown Friends Garden",
            "Princeton Day Garden",
            "Collegiate Garden",
            "Horace Mann Garden",
            "Trinity Garden"
        };

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

        private readonly IDictionary<string, bool> universities = new Dictionary<string, bool>
        {
            // bool = Is school prestigious or not
            {"Princeton University", true},
            {"Harvard University", true},
            {"Yale University", true},
            {"Stanford University", true},
            {"Georgetown University", true},
            {"Cornell University", false},
            {"Washington University in St. Louis", false}
        };

        public string PickKinderGarten()
        {
            return kinderGartens.ElementAt(GetRandom.Next(0, kinderGartens.Count() - 1));
        }

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

        public string PickUniversity(bool successful = false)
        {
            var tempStorage = universities.Keys.Where(x => universities[x] == successful);
            return tempStorage.ElementAt(GetRandom.Next(0, tempStorage.Count() - 1));
        }
    }
}