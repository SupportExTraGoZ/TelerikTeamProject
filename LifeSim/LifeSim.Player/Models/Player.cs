using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Player.Models
{
    public class Player : AbstractPlayer
    {
        public Player(string firstname, string lastname, GenderType gender, Birthplaces birthplace,
            IFamilyGenerator familyGenerator) : base(firstname, lastname, gender, birthplace)
        {
            var familyNames = familyGenerator.ChooseParentNames();
            var fatherName = familyNames[0].Split();
            var motherName = familyNames[1].Split();
            Father = new Parent(fatherName[0], fatherName[1], GenderType.Male, familyGenerator.ChooseBirthplace(),
                familyGenerator);
            Mother = new Parent(motherName[0], motherName[1], GenderType.Female, familyGenerator.ChooseBirthplace(),
                familyGenerator);
        }

        public Parent Father { get; }
        public Parent Mother { get; }
    }
}