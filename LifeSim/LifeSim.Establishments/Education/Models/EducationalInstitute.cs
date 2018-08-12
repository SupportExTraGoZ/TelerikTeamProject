using System;
using LifeSim.Establishments.AbstractEstablishment.Models;
using LifeSim.Establishments.Education.Contracts;
using LifeSim.Establishments.Education.Enum;

namespace LifeSim.Establishments.Education
{
    public abstract class EducationalInstitute : Establishment, IEducationalInstitute
    {
        public EducationalInstitute(string name, int startYear)
        {
            Name = name;
            StartYear = startYear;
        }

        //there is field buildingName in Establishment class
        //Im not sure if its good practise the code below..
        //access the base Property through Name property
        public string Name
        {
            get => base.BuildingName;
            set => base.BuildingName = value;
                
        }

        public EducationType EducationType { get; set; }

        public int StartYear { get; set; }
        public int GraduateYear { get; set; }
    }
}