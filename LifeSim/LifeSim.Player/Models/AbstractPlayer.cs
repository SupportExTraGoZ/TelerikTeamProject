using System;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using System.Text;

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

        // Specifications
        public bool IsTakingLessons { get; set; }
        public bool IsSuccessfulAtPrimarySchool { get; set; }
        public bool IsSuccessfulAtHighSchool { get; set; }
        public bool IsSuccessfulAtUniversity { get; set; }
        // End Of Specifications

        public bool IsDead { get; set; } = false;
        public GenderType Gender { get; set; }
        public Birthplaces Birthplace { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public Parent Father { get; set; }
        public Parent Mother { get; set; }

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
            stringBuilder.AppendLine($"More to be added...");

            return stringBuilder.ToString();
        }
    }
}