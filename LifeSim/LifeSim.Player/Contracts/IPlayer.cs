using System;
using LifeSim.Establishments.Education.HighSchool;
using LifeSim.Establishments.Education.HighSchool.Contracts;
using LifeSim.Establishments.Education.Models.KinderGarten.Contracts;
using LifeSim.Establishments.Education.Models.KinderGarten.Models;
using LifeSim.Establishments.Education.PrimarySchool;
using LifeSim.Establishments.Education.PrimarySchool.Contracts;
using LifeSim.Establishments.Education.University;
using LifeSim.Establishments.Education.University.Contracts;
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
        IParent Father { get; set; }
        IParent Mother { get; set; }
        IKinderGarten KinderGarten { get; set; }
        IPrimarySchool PrimarySchool { get; set; }
        IHighSchool HighSchool { get; set; }
        IUniversity University { get; set; }
        IJob Job { get; set; }

        string GetBirthplace();
    }
}