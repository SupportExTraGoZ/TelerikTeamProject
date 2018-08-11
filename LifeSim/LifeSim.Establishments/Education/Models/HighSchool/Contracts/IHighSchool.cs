using LifeSim.Establishments.Education.Contracts;
using System.Collections.Generic;

namespace LifeSim.Establishments.Education.HighSchool.Contract
{
    public interface IHighSchool : IEducationalInstitute
    {
        IList<string> HighSchoolNames { get; }
    }
}