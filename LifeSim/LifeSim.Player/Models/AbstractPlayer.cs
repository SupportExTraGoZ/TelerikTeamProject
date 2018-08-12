using System;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using System.Text;
using LifeSim.Establishments.Education.PrimarySchool;
using LifeSim.Establishments.Education.HighSchool;
using LifeSim.Establishments.Education.University;
using LifeSim.Establishments.Education.Models.KinderGarten.Models;

namespace LifeSim.Player.Models
{
    public abstract class AbstractPlayer : IPlayer
    {
        private string firstname;
        private string lastname;

        public AbstractPlayer(string firstname, string lastname, GenderType gender, Birthplaces birthplace)
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
                    throw new Exceptions.Models.CustomException(Exceptions.Models.Exceptions.FirstNameTooShort);
                if (value.Length > 15)
                    throw new Exceptions.Models.CustomException(Exceptions.Models.Exceptions.FirstNameTooLong);

                firstname = value;
            }
        }

        public string LastName
        {
            get => lastname;
            set
            {
                if (value.Length < 4)
                    throw new Exceptions.Models.CustomException(Exceptions.Models.Exceptions.LastNameTooShort);
                if (value.Length > 15)
                    throw new Exceptions.Models.CustomException(Exceptions.Models.Exceptions.LastNameTooLong);

                lastname = value;
            }
        }

        public int Age { get; set; }
        public int Money { get; set; }
        public int Friends { get; set; }

        // Specifications
        public bool IsTakingLessons { get; set; }
        public bool IsSuccessfulAtPrimarySchool { get; set; }
        public bool HasAttendedPrimarySchool { get; set; }
        public bool IsSuccessfulAtHighSchool { get; set; }
        public bool HasAttendedHighSchool { get; set; }
        public bool IsSuccessfulAtUniversity { get; set; }
        public bool HasAttendedUniversity { get; set; }
        public bool HasChildren { get; set; }
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
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"You, {this.FirstName} {this.LastName} have lived up to the age of {this.Age}.");
            stringBuilder.AppendLine($"But You passed away during a car accident...");
            stringBuilder.AppendLine($"Parents:");
            if (this.Father.IsDead)
                stringBuilder.AppendLine($"{this.Father.FirstName} {this.Father.LastName} has passed away at the age of {this.Father.Age}");
            else
                stringBuilder.AppendLine($"{this.Father.FirstName} {this.Father.LastName} is living at the age of {this.Father.Age}");
            if (this.Mother.IsDead)
                stringBuilder.AppendLine($"{this.Mother.FirstName} {this.Mother.LastName} has passed away at the age of {this.Mother.Age}");
            else
                stringBuilder.AppendLine($"{this.Mother.FirstName} {this.Mother.LastName} is living at the age of {this.Mother.Age}");

            stringBuilder.AppendLine("----- WEALTH -----");
            stringBuilder.AppendLine($"You have passed away with ${this.Money} in your bank account.");

            if (this.Money > 0)
                if (this.HasChildren)
                    stringBuilder.AppendLine("Your fortune will be passed onto your children...");
                else
                    stringBuilder.AppendLine("Your fortune will be donated to charities...");

            stringBuilder.AppendLine("----- FRIENDS -----");
            stringBuilder.AppendLine($"You've made {this.Friends} new friends throughout your life.");

            // Successful Or Not during education period
            // TODO: Add Graduation Period for each educational institute
            stringBuilder.AppendLine("----- EDUCATION -----");
            if (this.HasAttendedPrimarySchool)
            {
                stringBuilder.AppendLine($"You've started Primary School at {this.PrimarySchool.BuildingName}, on {this.PrimarySchool.StartYear}");
                if (this.IsSuccessfulAtPrimarySchool) stringBuilder.AppendLine("You were successful in Primary School.");
                else stringBuilder.AppendLine("You weren't successful in Primary School.");
                stringBuilder.AppendLine($"You've graduated Primary School at {this.PrimarySchool.BuildingName}, on {this.PrimarySchool.GraduateYear}");
            }
            if (this.HasAttendedHighSchool)
            {
                stringBuilder.AppendLine($"You've started High School at {this.HighSchool.BuildingName}, on {this.HighSchool.StartYear}");
                if (this.IsSuccessfulAtHighSchool) stringBuilder.AppendLine("You were successful in High School.");
                else stringBuilder.AppendLine("You weren't successful in High School.");
                stringBuilder.AppendLine($"You've graduated High School at {this.HighSchool.BuildingName}, on {this.HighSchool.GraduateYear}");
            }
            if (this.HasAttendedUniversity)
            {
                stringBuilder.AppendLine($"You've started University at {this.University.BuildingName}, on {this.University.StartYear}");
                if (this.IsSuccessfulAtUniversity) stringBuilder.AppendLine("You were successful in University.");
                else stringBuilder.AppendLine("You weren't successful in University.");
                stringBuilder.AppendLine($"You've graduated University at {this.University.BuildingName}, on {this.University.GraduateYear}");
            }

            // Was Taking Lessons?
            if (this.IsTakingLessons) stringBuilder.AppendLine("You were taking extra private lessons.");
            else stringBuilder.AppendLine("You weren't taking extra private lessons.");

            stringBuilder.AppendLine("----- INFO -----");
            stringBuilder.AppendLine($"More to be added...");

            return stringBuilder.ToString();
        }
    }
}