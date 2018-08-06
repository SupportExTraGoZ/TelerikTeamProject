using LifeSim.Establishments.Education.Enum;

namespace LifeSim.Establishments.Education.Contracts
{
    public interface IEducationalInstitute
    {
        string Name { get; }

        int StartYear { get; set; }

        int GraduateYear { get; set; }

        EducationType EducationType { get; set; }
    }
}