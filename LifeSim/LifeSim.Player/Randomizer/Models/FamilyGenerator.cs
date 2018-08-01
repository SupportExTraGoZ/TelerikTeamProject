﻿using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Player.Randomizer.Models
{
    public class FamilyGenerator : IFamilyGenerator
    {
        private readonly Random GetRandom = new Random();

        private readonly string[] FatherNames =
            {"John Doesh", "Vasilis Petrovich", "Ivan Kitukovich", "Pedro Lamas", "Gosho Toshov"};

        private readonly string[] MotherNames =
            {"Mariya Doesh", "Petranka Petrovich", "Ivanka Kitukovich", "Milla Lamas", "Pesha Toshova"};

        public string[] ChooseParentNames()
        {
            string fatherName, motherName;
            fatherName = FatherNames[GetRandom.Next(0, FatherNames.Length - 1)];
            motherName = MotherNames[GetRandom.Next(0, MotherNames.Length - 1)];
            return new[] {fatherName, motherName};
        }

        public Birthplaces ChooseBirthplace()
        {
            return (Birthplaces) GetRandom.Next(0, 3);
        }

        public int ChooseAge()
        {
            return GetRandom.Next(30, 50);
        }
    }
}