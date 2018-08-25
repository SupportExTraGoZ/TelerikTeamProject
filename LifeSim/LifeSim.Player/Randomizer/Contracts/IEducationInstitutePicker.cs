﻿namespace LifeSim.Player.Randomizer.Contracts
{
    public interface IEducationInstitutePicker
    {
        string PickKinderGarten();
        string PickPrimarySchool(bool successful = false);
        string PickHighSchool(bool successful = false);
        string PickUniversity(bool successful = false);
    }
}