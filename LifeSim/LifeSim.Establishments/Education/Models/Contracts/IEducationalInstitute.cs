using LifeSim.Establishments.Education.Enum;

namespace LifeSim.Establishments.Education.Contracts
{
    public interface IEducationalInstitute
    {
        int StartYear { get; set; }

        int GraduateYear { get; set; }

        EducationType EducationType { get; set; }
    }
}