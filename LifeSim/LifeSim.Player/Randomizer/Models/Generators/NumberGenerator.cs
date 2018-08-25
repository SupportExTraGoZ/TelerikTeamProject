using System;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Contracts.Generators;

namespace LifeSim.Player.Randomizer.Models.Generators
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly Random GetRandom = new Random();

        public int ChooseNumber(int min = 0, int max = 20)
        {
            return GetRandom.Next(min, max);
        }

        public int RandomChance()
        {
            return GetRandom.Next(0, 100);
        }
    }
}