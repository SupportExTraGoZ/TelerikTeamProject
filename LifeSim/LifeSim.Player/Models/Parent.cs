using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Player.Models
{
    public class Parent : AbstractPlayer
    {
        public Parent(string firstname, string lastname, GenderType gender, Birthplaces birthplace,
            IFamilyGenerator familyGenerator) : base(firstname, lastname, gender, birthplace)
        {
            Age = familyGenerator.ChooseAge();
            BirthDate = DateTime.Now.AddYears(-Age);
        }
    }
}