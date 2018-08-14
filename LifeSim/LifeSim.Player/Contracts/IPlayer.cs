using System;
using LifeSim.Establishments.Education.HighSchool;
using LifeSim.Establishments.Education.Models.KinderGarten.Models;
using LifeSim.Establishments.Education.PrimarySchool;
using LifeSim.Establishments.Education.University;
using LifeSim.Establishments.Job;
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
        bool IsDead { get; set; }

        // Specifications
        bool HasTakenLessons { get; set; }
        bool IsSuccessfulAtPrimarySchool { get; set; }
        bool HasAttendedPrimarySchool { get; set; }
        bool IsSuccessfulAtHighSchool { get; set; }
        bool HasAttendedHighSchool { get; set; }
        bool IsSuccessfulAtUniversity { get; set; }
        bool HasAttendedUniversity { get; set; }
        bool HasChildren { get; set; }
        bool HasJob { get; }
        bool IsCEO { get; set; }

        bool IsRetired { get; set; }
        // End Of Specifications

        GenderType Gender { get; set; }
        DateTime BirthDate { get; set; }
        Birthplaces Birthplace { get; set; }
        Parent Father { get; set; }
        Parent Mother { get; set; }
        KinderGarten KinderGarten { get; set; }
        PrimarySchool PrimarySchool { get; set; }
        HighSchool HighSchool { get; set; }
        University University { get; set; }
        IJob Job { get; set; }

        string GetBirthplace();
    }
}