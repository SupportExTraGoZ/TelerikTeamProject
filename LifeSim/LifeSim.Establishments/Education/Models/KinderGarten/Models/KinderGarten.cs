using LifeSim.Establishments.Education.Models.KinderGarten.Contract;

namespace LifeSim.Establishments.Education.Models.KinderGarten.Models
{
    public class KinderGarten : EducationalInstitute , IKinderGarten
    {
        public KinderGarten(string name,int startYear, int graduateYear) : base(name,startYear,graduateYear)
        {

        }
    }
}
