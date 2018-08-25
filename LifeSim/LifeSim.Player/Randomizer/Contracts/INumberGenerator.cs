namespace LifeSim.Player.Randomizer.Contracts
{
    public interface INumberGenerator
    {
        int ChooseNumber(int min = 0, int max = 20);
        int RandomChance();
    }
}