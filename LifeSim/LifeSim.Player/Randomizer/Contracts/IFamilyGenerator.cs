using LifeSim.Player.Enums;

namespace LifeSim.Player.Randomizer.Contracts
{
    public interface IFamilyGenerator : IGenerator
    {
        string[] ChooseParentNames();
        Birthplaces ChooseBirthplace();
        int ChooseAge();
        int ChooseAge(int end);
    }
}