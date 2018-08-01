using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;
namespace LifeSim.Player.Randomizer.Models
{
    public class FamilyGenerator : IFamilyGenerator
    {
        private string[] FatherNames = new string[] { "John Doesh", "Vasilis Petrovich", "Ivan Kitukovich", "Pedro Lamas", "Gosho Toshov" };
        private string[] MotherNames = new string[] { "Mariya Doesh", "Petranka Petrovich", "Ivanka Kitukovich", "Milla Lamas", "Pesha Toshova" };
        private readonly Random GetRandom = new Random();

        public string[] ChooseParentNames()
        {
            string fatherName, motherName;
            fatherName = FatherNames[GetRandom.Next(0, FatherNames.Length - 1)];
            motherName = MotherNames[GetRandom.Next(0, MotherNames.Length - 1)];
            return new string[] { fatherName, motherName };
        }

        public Birthplaces ChooseBirthplace()
        {
            return (Birthplaces)GetRandom.Next(0, 3);
        }

        public int ChooseAge()
        {
            return GetRandom.Next(30, 50);
        }
    }
}