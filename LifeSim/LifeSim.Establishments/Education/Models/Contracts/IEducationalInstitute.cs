using LifeSim.Establishments.Education.Enum;

namespace LifeSim.Establishments.Education.Contracts
{
    public interface IEducationalInstitute
    {
        string Name { get; }

        EducationType EducationType { get; set; }
    }
}