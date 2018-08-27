using LifeSim.Establishments.AbstractEstablishment.Contracts;

namespace LifeSim.Establishments.Education.Models.Contracts
{
    public interface IEducationalInstitute : IEstablishment
    {
        int StartYear { get; set; }

        int GraduateYear { get; set; }
    }
}