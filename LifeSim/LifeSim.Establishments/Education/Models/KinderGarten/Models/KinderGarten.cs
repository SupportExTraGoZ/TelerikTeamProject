using LifeSim.Establishments.Education.Models.KinderGarten.Contracts;

namespace LifeSim.Establishments.Education.Models.KinderGarten.Models
{
    public class KinderGarten : EducationalInstitute, IKinderGarten
    {
        public KinderGarten(string name, int startYear) : base(name, startYear)
        {
        }
    }
}