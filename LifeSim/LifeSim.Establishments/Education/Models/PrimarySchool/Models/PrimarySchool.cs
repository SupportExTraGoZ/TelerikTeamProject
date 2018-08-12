using LifeSim.Establishments.Education.PrimarySchool.Contracts;

namespace LifeSim.Establishments.Education.PrimarySchool
{
    public class PrimarySchool : EducationalInstitute, IPrimarySchool
    {
        public PrimarySchool(string name, int startYear) : base(name, startYear)
        {
        }
    }
}