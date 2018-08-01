using LifeSim.Establishments.Education.Contracts;
using LifeSim.Establishments.Education.Enum;

namespace LifeSim.Establishments.Education
{
    public abstract class EducationalInstitute : IEducationalInstitute
    {
        protected EducationalInstitute(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public EducationType EducationType { get; set; }
    }
}