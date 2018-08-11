﻿using System;
using LifeSim.Player.Enums;
using LifeSim.Player.Models;

namespace LifeSim.Player.Contracts
{
    public interface IPlayer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }

        // Specifications
        int Friends { get; set; }
        int Money { get; set; }
        bool IsTakingLessons { get; set; }
        bool IsSuccessfulAtPrimarySchool { get; set; }
        bool IsSuccessfulAtHighSchool { get; set; }
        bool IsSuccessfulAtUniversity { get; set; }
        bool HasChildren { get; set; }
        // End Of Specifications

        bool IsDead { get; set; }
        GenderType Gender { get; set; }
        DateTime BirthDate { get; set; }
        Birthplaces Birthplace { get; set; }
        string GetBirthplace();
        Parent Father { get; set; }
        Parent Mother { get; set; }
    }
}