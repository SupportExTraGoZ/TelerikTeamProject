using System;
using LifeSim.Player.Randomizer.Contracts;
namespace LifeSim.Player.Randomizer.Models
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly Random GetRandom = new Random();

        public int ChooseNumber(int min = 0, int max = 20)
        {
            return GetRandom.Next(min, max);
        }
    }
}
