using LifeSim.Player.Enums;

namespace LifeSim.Player.Randomizer.Contracts.Generators
{
    public interface IFamilyGenerator
    {
        string[] ChooseParentNames();
        Birthplaces ChooseBirthplace();
        int ChooseAge();
        int ChooseAge(int end);
    }
}