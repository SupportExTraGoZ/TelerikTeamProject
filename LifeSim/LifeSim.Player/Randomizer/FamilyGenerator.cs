using System;
using LifeSim.Player.Enums;
namespace LifeSim.Player.Randomizer
{
    public static class FamilyGenerator
    {
        private static string[] FatherNames = new string[] { "John Doesh", "Vasilis Petrovich", "Ivan Kitukovich", "Pedro Lamas", "Gosho Toshov" };
        private static string[] MotherNames = new string[] { "Mariya Doesh", "Petranka Petrovich", "Ivanka Kitukovich", "Milla Lamas", "Pesha Toshova" };
        private static Random GetRandom = new Random();

        public static string[] ChooseParentNames()
        {
            string fatherName, motherName;
            fatherName = FatherNames[GetRandom.Next(0, 2)];
            motherName = MotherNames[GetRandom.Next(0, 2)];
            return new string[] { fatherName, motherName };
        }

        public static Birthplaces ChooseBirthplace()
        {
            return (Birthplaces)GetRandom.Next(0, 2);
        }

        public static int ChooseAge()
        {
            return GetRandom.Next(30, 50);
        }
    }
}