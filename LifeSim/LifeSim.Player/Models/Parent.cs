using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Player.Models
{
    public class Parent : AbstractPlayer
    {
        public Parent(string firstname, string lastname, GenderType gender, Birthplaces birthplace, IFamilyGenerator familyGenerator) : base(firstname, lastname, gender, birthplace)
        {
            this.Age = familyGenerator.ChooseAge();
            this.BirthDate = DateTime.Now.AddYears(-this.Age);
        }
    }
}
