using LifeSim.Player.Enums;

namespace LifeSim.Player.Randomizer.Contracts
{
    public interface IFamilyGenerator
    {
        string[] ChooseParentNames();
        Birthplaces ChooseBirthplace();
        int ChooseAge();
    }
}