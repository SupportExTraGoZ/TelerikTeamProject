using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Establishments.Education.HighSchool;
using LifeSim.Establishments.Education.HighSchool.Contracts;
using LifeSim.Establishments.Education.Models.KinderGarten.Contracts;
using LifeSim.Establishments.Education.Models.KinderGarten.Models;
using LifeSim.Establishments.Education.PrimarySchool;
using LifeSim.Establishments.Education.PrimarySchool.Contracts;
using LifeSim.Establishments.Education.University;
using LifeSim.Establishments.Education.University.Contracts;

namespace LifeSim.Core.Engine.Factories
{
    public class EducationalInstituteFactory : IEducationalInstituteFactory
    {
        public IHighSchool CreateHighSchool(string name, int startYear)
        {
            return new HighSchool(name, startYear);
        }

        public IKinderGarten CreateKinderGarten(string name, int startYear)
        {
            return new KinderGarten(name, startYear);
        }

        public IPrimarySchool CreatePrimarySchool(string name, int startYear)
        {
            return new PrimarySchool(name, startYear);
        }

        public IUniversity CreateUniversity(string name, int startYear)
        {
            return new University(name, startYear);
        }
    }
}
