using LifeSim.Establishments.Education.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Education.Contracts
{
    public interface IEducationalInstitute
    {
        string Name { get; }

        EducationType EducationType { get; set; }



    }
}
