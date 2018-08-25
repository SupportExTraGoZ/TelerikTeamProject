using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Player.Models
{
    public class Player : AbstractPlayer
    {
        public Player(string firstname, string lastname, GenderType gender, Birthplaces birthplace,
            IGenerator generator) : base(firstname, lastname, gender, birthplace)
        {
            var familyNames = generator.FamilyGenerator.ChooseParentNames();
            var fatherName = familyNames[0].Split();
            var motherName = familyNames[1].Split();

            Father = new Parent(fatherName[0], fatherName[1], GenderType.Male, generator.FamilyGenerator.ChooseBirthplace(),
                generator.FamilyGenerator.ChooseAge());
            Mother = new Parent(motherName[0], motherName[1], GenderType.Female, generator.FamilyGenerator.ChooseBirthplace(),
                generator.FamilyGenerator.ChooseAge(Father.Age));
        }
    }
}