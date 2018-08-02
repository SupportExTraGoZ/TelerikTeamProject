using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Models;

namespace LifeSim.Player.Contracts
{
    public interface IPlayer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        GenderType Gender { get; set; }
        DateTime BirthDate { get; set; }
        Birthplaces Birthplace { get; set; }
        string GetBirthplace();
        Parent Father { get; set; }
        Parent Mother { get; set; }
    }
}