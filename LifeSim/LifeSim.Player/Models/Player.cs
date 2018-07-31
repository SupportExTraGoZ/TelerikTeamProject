using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Contracts;
using LifeSim.Player.Randomizer;
using LifeSim.Player.Models;

namespace LifeSim.Player.Models
{
    public class Player : AbstractPlayer
    {
        public Parent Father { get; private set; }
        public Parent Mother { get; private set; }
        public Player(string firstname, string lastname, GenderType gender, Birthplaces birthplace) : base(firstname, lastname, gender, birthplace)
        {
            var familyNames = FamilyGenerator.ChooseParentNames();
            var fatherName = familyNames[0].Split();
            var motherName = familyNames[1].Split();
            this.Father = new Parent(fatherName[0], fatherName[1], GenderType.Male, FamilyGenerator.ChooseBirthplace());
            this.Mother = new Parent(motherName[0], motherName[1], GenderType.Female, FamilyGenerator.ChooseBirthplace());
        }
    }
}