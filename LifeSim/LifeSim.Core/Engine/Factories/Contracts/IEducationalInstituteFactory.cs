using LifeSim.Establishments.Education.Models.HighSchool.Contracts;
using LifeSim.Establishments.Education.Models.KinderGarten.Contracts;
using LifeSim.Establishments.Education.Models.PrimarySchool.Contracts;
using LifeSim.Establishments.Education.Models.University.Contracts;

namespace LifeSim.Core.Engine.Factories.Contracts
{
    public interface IEducationalInstituteFactory
    {
        IKinderGarten CreateKinderGarten(string name, int startYear);

        IPrimarySchool CreatePrimarySchool(string name, int startYear);

        IHighSchool CreateHighSchool(string name, int startYear);

        IUniversity CreateUniversity(string name, int startYear);
    }
}