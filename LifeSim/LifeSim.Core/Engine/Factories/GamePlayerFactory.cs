using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Core.Engine.Factories
{
    public class GamePlayerFactory : IGamePlayerFactory
    {
        public IPlayer CreatePlayer(string firstname, string lastname, GenderType gender, Birthplaces birthplace,
            IFamilyGenerator familyGenerator)
        {
            return new Player.Models.Player(firstname, lastname, gender, birthplace, familyGenerator);
        }
    }
}
