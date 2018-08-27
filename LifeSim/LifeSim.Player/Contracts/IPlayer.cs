using System;
using LifeSim.Establishments.Education.Models.HighSchool.Contracts;
using LifeSim.Establishments.Education.Models.KinderGarten.Contracts;
using LifeSim.Establishments.Education.Models.PrimarySchool.Contracts;
using LifeSim.Establishments.Education.Models.University.Contracts;
using LifeSim.Establishments.Job;
using LifeSim.Establishments.Job.Contracts;
using LifeSim.Player.Enums;

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