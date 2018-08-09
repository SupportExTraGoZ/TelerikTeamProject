using System;
namespace LifeSim.Player.Randomizer.Contracts
{
    public interface INumberGenerator : IGenerator
    {
        int ChooseNumber(int min = 0, int max = 20);
    }
}
