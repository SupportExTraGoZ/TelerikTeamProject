using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer;

namespace LifeSim.Player.Models
{
    public class Parent : AbstractPlayer
    {
        public Parent(string firstname, string lastname, GenderType gender, Birthplaces birthplace) : base(firstname, lastname, gender, birthplace)
        {
            this.Age = FamilyGenerator.ChooseAge();
            this.BirthDate = DateTime.Now.AddYears(-this.Age);
        }
    }
}
