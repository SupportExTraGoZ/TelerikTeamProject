using LifeSim.Establishments.Education.Contracts;
using System.Collections.Generic;

namespace LifeSim.Establishments.Education.PrimarySchool.Contract
{
    public interface IPrimarySchool : IEducationalInstitute
    {
        IList<string> PrimarySchoolNames { get; }
    }
}