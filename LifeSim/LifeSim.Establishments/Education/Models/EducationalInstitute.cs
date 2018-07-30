using LifeSim.Establishments.Education.Contracts;
using LifeSim.Establishments.Education.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeSim.Establishments.Education
{
    public abstract class EducationalInstitute : IEducationalInstitute
    {
        private readonly string name;

        protected EducationalInstitute(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Invalid name!");

            if (name.Length < 5 || name.Length > 30)
                throw new ArgumentOutOfRangeException("Education Institute length should be between 5 and 30 symbols.");
            
            this.name = name;
        }

        public string Name
        {
            get => this.name;
        }
        
        public EducationType EducationType { get; set; }
    }
}
