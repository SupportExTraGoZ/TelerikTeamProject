using System;
using LifeSim.Player.Enums;

namespace LifeSim.Player.Models
{
    public class Parent : AbstractPlayer
    {
        public Parent(string firstname, string lastname, GenderType gender, Birthplaces birthplace,
            int age) : base(firstname, lastname, gender, birthplace)
        {
            Age = age;
            BirthDate = DateTime.Now.AddYears(-Age);
        }
    }
}