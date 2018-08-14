using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Player.Randomizer.Models
{
    public class FamilyGenerator : IFamilyGenerator
    {
        private const int minParentAge = 25;
        private const int maxParentAge = 55;

        private readonly string[] FatherNames =
            {"John Doesh", "Vasilis Petrovich", "Ivan Kitukovich", "Pedro Lamas", "Gosho Toshov"};

        private readonly Random GetRandom = new Random();

        private readonly string[] MotherNames =
            {"Mariya Doesh", "Petranka Petrovich", "Ivanka Kitukovich", "Milla Lamas", "Pesha Toshova"};

        public string[] ChooseParentNames()
        {
            string fatherName, motherName;
            var num = GetRandom.Next(0, FatherNames.Length - 1);
            fatherName = FatherNames[num];
            motherName = MotherNames[num];
            return new[] {fatherName, motherName};
        }

        public Birthplaces ChooseBirthplace()
        {
            return (Birthplaces) GetRandom.Next(0, 3);
        }

        public int ChooseAge()
        {
            return GetRandom.Next(minParentAge, maxParentAge);
        }

        public int ChooseAge(int end)
        {
            return GetRandom.Next(minParentAge, end);
        }
    }
}