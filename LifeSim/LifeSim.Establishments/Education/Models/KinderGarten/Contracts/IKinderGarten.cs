using LifeSim.Establishments.Education.Contracts;
using System.Collections.Generic;

namespace LifeSim.Establishments.Education.Models.KinderGarten.Contract
{
    public interface IKinderGarten : IEducationalInstitute
    {
        IList<string> KinderGartenNames { get; }
    }

}
