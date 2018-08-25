namespace LifeSim.Player.Randomizer.Contracts.Generators
{
    public interface INumberGenerator
    {
        int ChooseNumber(int min = 0, int max = 20);
        int RandomChance();
    }
}