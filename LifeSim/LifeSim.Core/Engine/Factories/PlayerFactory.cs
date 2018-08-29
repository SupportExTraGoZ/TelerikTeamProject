using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Core.Engine.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string firstname, string lastname, GenderType gender, Birthplaces birthplace,
            IGenerator generator)
        {
            return new Player.Models.Player(firstname, lastname, gender, birthplace, generator);
        }
    }
}