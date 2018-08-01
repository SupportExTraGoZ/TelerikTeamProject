using LifeSim.Establishments.Education.PrimarySchool.Contract;

namespace LifeSim.Establishments.Education.PrimarySchool
{
    public class PrimarySchool : EducationalInstitute, IPrimarySchool
    {
        public PrimarySchool(string name) : base(name)
        {
        }
    }
}