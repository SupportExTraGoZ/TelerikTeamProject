using LifeSim.Establishments.Education.HighSchool.Contracts;
using LifeSim.Establishments.Education.Models.KinderGarten.Contracts;
using LifeSim.Establishments.Education.PrimarySchool.Contracts;
using LifeSim.Establishments.Education.University.Contracts;

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
