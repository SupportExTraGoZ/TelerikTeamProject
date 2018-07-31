using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Models;

namespace LifeSim.Player
{
    public class Player : AbstractPlayer
    {
        public Player(string firstname, string lastname, GenderType gender, Birthplaces birthplace) : base(firstname, lastname, gender, birthplace)
        {

        }
    }
}
