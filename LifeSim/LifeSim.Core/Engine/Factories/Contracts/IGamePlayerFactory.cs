﻿using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Player.Randomizer.Contracts;

namespace LifeSim.Core.Engine.Factories.Contracts
{
    public interface IGamePlayerFactory
    {
        IPlayer CreatePlayer(string firstname, string lastname, GenderType gender, Birthplaces birthplace,
            IFamilyGenerator familyGenerator);
    }
}