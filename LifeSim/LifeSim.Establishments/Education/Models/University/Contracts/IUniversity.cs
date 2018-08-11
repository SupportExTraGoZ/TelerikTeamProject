using LifeSim.Establishments.Education.Contracts;
using System.Collections.Generic;

namespace LifeSim.Establishments.Education.University.Contract
{
    public interface IUniversity : IEducationalInstitute
    {
        IList<string> UniverityNames { get; }
    }
}