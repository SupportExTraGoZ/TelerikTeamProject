using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Contracts.Generators;

namespace LifeSim.Player.Randomizer.Models
{
    public class Generator : IGenerator
    {
        public Generator(INumberGenerator numberGenerator, IFamilyGenerator familyGenerator, IEducationInstitutePicker educationInstitutePicker)
        {
            NumberGenerator = numberGenerator;
            FamilyGenerator = familyGenerator;
            EducationInstitutePicker = educationInstitutePicker;
        }

        public INumberGenerator NumberGenerator { get; }

        public IFamilyGenerator FamilyGenerator { get; }

        public IEducationInstitutePicker EducationInstitutePicker { get; }
    }
}
