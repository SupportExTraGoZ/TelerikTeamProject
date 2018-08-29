using LifeSim.Establishments.Education.Models.University.Contracts;

namespace LifeSim.Establishments.Education.Models.University.Models
{
    public class University : EducationalInstitute, IUniversity
    {
        public University(string name, int startYear) : base(name, startYear)
        {
        }
    }
}