using LifeSim.Establishments.Education.Models.HighSchool.Contracts;

namespace LifeSim.Establishments.Education.Models.HighSchool.Models
{
    public class HighSchool : EducationalInstitute, IHighSchool
    {
        public HighSchool(string name, int startYear) : base(name, startYear)
        {
        }
    }
}