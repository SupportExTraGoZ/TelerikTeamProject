using System;
using LifeSim.Establishments.Education.HighSchool;
using LifeSim.Establishments.Education.PrimarySchool;
using LifeSim.Establishments.Education.University;
using LifeSim.Player.Enums;
using LifeSim.Player.Models;

namespace LifeSim.Player.Contracts
{
    public interface IPlayer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        int Money { get; set; }
        int Friends { get; set; }

        // Specifications
        bool IsTakingLessons { get; set; }
        bool IsSuccessfulAtPrimarySchool { get; set; }
        bool HasAttendedPrimarySchool { get; set; }
        bool IsSuccessfulAtHighSchool { get; set; }
        bool HasAttendedHighSchool { get; set; }
        bool IsSuccessfulAtUniversity { get; set; }
        bool HasAttendedUniversity { get; set; }
        bool HasChildren { get; set; }
        // End Of Specifications

        bool IsDead { get; set; }
        GenderType Gender { get; set; }
        DateTime BirthDate { get; set; }
        Birthplaces Birthplace { get; set; }
        string GetBirthplace();
        Parent Father { get; set; }
        Parent Mother { get; set; }
        PrimarySchool PrimarySchool { get; set; }
        HighSchool HighSchool { get; set; }
        University University { get; set; }
    }
}