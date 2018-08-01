using System;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
using LifeSim.Exceptions;

namespace LifeSim.Player.Models
{
    public abstract class AbstractPlayer : IPlayer
    {
        private string firstname;
        private string lastname;
        public string FirstName
        {
            get
            {
                return this.firstname;
            }
            set
            {
                if (value.Length < 4)
                    throw new ArgumentOutOfRangeException(Exceptions.Exceptions.FirstNameTooShort);
                if (value.Length > 15)
                    throw new ArgumentOutOfRangeException(Exceptions.Exceptions.FirstNameTooLong);

                this.firstname = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastname;
            }
            set
            {
                if (value.Length < 4)
                    throw new ArgumentOutOfRangeException(Exceptions.Exceptions.LastNameTooShort);
                if (value.Length > 15)
                    throw new ArgumentOutOfRangeException(Exceptions.Exceptions.LastNameTooLong);

                this.lastname = value;
            }
        }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public Birthplaces Birthplace { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;

        public AbstractPlayer(string firstname, string lastname, GenderType gender, Birthplaces birthplace)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Gender = gender;
            this.Birthplace = birthplace;
        }

        public string GetGender()
        {
            switch (this.Gender)
            {
                case GenderType.Male:
                    return "Male";
                case GenderType.Female:
                    return "Female";
                default:
                    return "Invalid Gender.";
            }
        }

        public string GetBirthplace()
        {
            switch (this.Birthplace)
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
    }
}