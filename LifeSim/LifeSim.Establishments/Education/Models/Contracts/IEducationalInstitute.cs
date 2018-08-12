using LifeSim.Establishments.AbstractEstablishment.Contracts;

namespace LifeSim.Establishments.Education.Contracts
{
    public interface IEducationalInstitute
    {
        int StartYear { get; set; }

        int GraduateYear { get; set; }
    }
}