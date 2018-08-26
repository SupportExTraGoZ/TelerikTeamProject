using System;
using System.Text;
using LifeSim.Establishments.Education.HighSchool;
using LifeSim.Establishments.Education.Models.KinderGarten.Models;
using LifeSim.Establishments.Education.PrimarySchool;
using LifeSim.Establishments.Education.University;
using LifeSim.Establishments.Job;
using LifeSim.Exceptions.Models;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;

namespace LifeSim.Player.Models
{
    public abstract class AbstractPlayer : IPlayer
    {
        private string firstname;
        private string lastname;

        protected AbstractPlayer(string firstname, string lastname, GenderType gender, Birthplaces birthplace)
        {
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
            Birthplace = birthplace;
        }

        public string FirstName
        {
            get => firstname;
            set
            {
                if (value.Length < 4)
                    throw new CustomException(Exceptions.Models.Exceptions.FirstNameTooShort);
                if (value.Length > 15)
                    throw new CustomException(Exceptions.Models.Exceptions.FirstNameTooLong);

                firstname = value;
            }
        }

        public string LastName
        {
            get => lastname;
            set
            {
                if (value.Length < 4)
                    throw new CustomException(Exceptions.Models.Exceptions.LastNameTooShort);
                if (value.Length > 15)
                    throw new CustomException(Exceptions.Models.Exceptions.LastNameTooLong);

                lastname = value;
            }
        }

        public int Age { get; set; }
        public int Money { get; set; }
        public int Friends { get; set; }

        // Specifications
        public bool HasTakenLessons { get; set; }

        public bool IsSuccessfulAtPrimarySchool { get; set; }
        public bool HasAttendedPrimarySchool { get; set; }
        public bool IsSuccessfulAtHighSchool { get; set; }
        public bool HasAttendedHighSchool { get; set; }
        public bool IsSuccessfulAtUniversity { get; set; }
        public bool HasAttendedUniversity { get; set; }
        public bool HasChildren { get; set; }

        public bool HasJob => Job != null && (Job == null || Job.EndDate >= Job.StartDate);

        public bool IsCEO { get; set; }

        public bool IsRetired { get; set; }
        // End Of Specifications

        public bool IsDead { get; set; } = false;
        public GenderType Gender { get; set; }
        public Birthplaces Birthplace { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public Parent Father { get; set; }
        public Parent Mother { get; set; }
        public KinderGarten KinderGarten { get; set; }
        public PrimarySchool PrimarySchool { get; set; }
        public HighSchool HighSchool { get; set; }
        public University University { get; set; }
        public IJob Job { get; set; }

        public string GetBirthplace()
        {
            switch (Birthplace)
            {
                case Birthplaces.Chicago:
                    return "Chicago";
                case Birthplaces.LosAngeles:
                    return "Los Angeles";
                case Birthplaces.Miami:
                    return "Miami";
                case Birthplaces.NewYork:
                    return "New York";
                default:
                    return "Invalid Birthplace.";
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"You, {FirstName} {LastName} have lived up to the age of {Age}.");
            stringBuilder.AppendLine($"But You passed away during a car accident...");
            stringBuilder.AppendLine($"Parents:");
            stringBuilder.AppendLine(
                Father.IsDead
                    ? $"{Father.FirstName} {Father.LastName} has passed away at the age of {Father.Age}"
                    : $"{Father.FirstName} {Father.LastName} is living at the age of {Father.Age}");
            stringBuilder.AppendLine(
                Mother.IsDead
                    ? $"{Mother.FirstName} {Mother.LastName} has passed away at the age of {Mother.Age}"
                    : $"{Mother.FirstName} {Mother.LastName} is living at the age of {Mother.Age}");

            stringBuilder.AppendLine("----- WEALTH -----");
            stringBuilder.AppendLine(
                $"You have passed away with ${string.Format("{0:N0}", Money)} in your bank account.");

            if (Money > 0)
                stringBuilder.AppendLine(HasChildren
                    ? "Your fortune will be passed onto your children..."
                    : "Your fortune will be donated to charities...");

            stringBuilder.AppendLine("----- FRIENDS -----");
            stringBuilder.AppendLine($"You've made {Friends} new friends throughout your life.");

            // Successful Or Not during education period
            // TODO: Add Graduation Period for each educational institute
            stringBuilder.AppendLine("----- EDUCATION -----");
            if (HasAttendedPrimarySchool)
            {
                stringBuilder.AppendLine(
                    $"You've started Primary School at {PrimarySchool.BuildingName}, on {PrimarySchool.StartYear}");
                stringBuilder.AppendLine(IsSuccessfulAtPrimarySchool
                    ? "You were successful in Primary School."
                    : "You weren't successful in Primary School.");
                stringBuilder.AppendLine(
                    $"You've graduated Primary School at {PrimarySchool.BuildingName}, on {PrimarySchool.GraduateYear}");
            }
            if (HasAttendedHighSchool)
            {
                stringBuilder.AppendLine(
                    $"You've started High School at {HighSchool.BuildingName}, on {HighSchool.StartYear}");
                stringBuilder.AppendLine(IsSuccessfulAtHighSchool
                    ? "You were successful in High School."
                    : "You weren't successful in High School.");
                stringBuilder.AppendLine(
                    $"You've graduated High School at {HighSchool.BuildingName}, on {HighSchool.GraduateYear}");
            }
            if (HasAttendedUniversity)
            {
                stringBuilder.AppendLine(
                    $"You've started University at {University.BuildingName}, on {University.StartYear}");
                stringBuilder.AppendLine(IsSuccessfulAtUniversity
                    ? "You were successful in University."
                    : "You weren't successful in University.");
                stringBuilder.AppendLine(
                    $"You've graduated University at {University.BuildingName}, on {University.GraduateYear}");
            }
            // Was Taking Lessons?
            stringBuilder.AppendLine(HasTakenLessons
                ? "You were taking extra private lessons."
                : "You weren't taking extra private lessons.");

            stringBuilder.AppendLine("----- WORK -----");
            if (Job != null)
            {
                if (IsCEO)
                    stringBuilder.AppendLine("You've been CEO in your life.");
                stringBuilder.AppendLine($"You've worked as {Job.Profession}.");
                stringBuilder.AppendLine($"Started Work: {Job.StartDate.Year} | Retired: {Job.EndDate.Year}.");
                stringBuilder.AppendLine($"Your maximum salary was ${Job.MonthlySalary}.");
            }
            else
            {
                stringBuilder.AppendLine("You haven't had a job.");
            }

            return stringBuilder.ToString();
        }
    }
}