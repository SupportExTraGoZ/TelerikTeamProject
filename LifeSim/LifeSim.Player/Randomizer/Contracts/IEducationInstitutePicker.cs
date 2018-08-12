using System;
using System.Collections.Generic;

namespace LifeSim.Player.Randomizer.Contracts
{
    public interface IEducationInstitutePicker : IGenerator
    {
        string PickPrimarySchool(bool successful = false);
        string PickHighSchool(bool successful = false);
        string PickUniversity(bool successful = false);
    }
}