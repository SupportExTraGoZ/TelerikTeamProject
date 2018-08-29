using LifeSim.Establishments.AbstractEstablishment.Models;
using LifeSim.Establishments.Education.Models.Contracts;

namespace LifeSim.Establishments.Education.Models
{
    public abstract class EducationalInstitute : Establishment, IEducationalInstitute
    {
        public EducationalInstitute(string name, int startYear) : base(name)
        {
            StartYear = startYear;
        }

        public int StartYear { get; set; }
        public int GraduateYear { get; set; }
    }
}