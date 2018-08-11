using System.Collections.Generic;
using LifeSim.Establishments.Education.Contracts;

namespace LifeSim.Establishments.Education.HighSchool.Contracts
{
    public interface IHighSchool
    {
        IDictionary<string, bool> HighSchools { get; }
    }
}