using LifeSim.Establishments.Education.Models.PrimarySchool.Contracts;

namespace LifeSim.Establishments.Education.Models.PrimarySchool.Models
{
    public class PrimarySchool : EducationalInstitute, IPrimarySchool
    {
        public PrimarySchool(string name, int startYear) : base(name, startYear)
        {
        }
    }
}