using LifeSim.Player.Randomizer.Contracts.Generators;

namespace LifeSim.Player.Randomizer.Contracts
{
    public interface IGenerator
    {
        INumberGenerator NumberGenerator { get; }
        IFamilyGenerator FamilyGenerator { get; }
        IEducationInstitutePicker EducationInstitutePicker { get; }
    }
}