using System;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;

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
                    throw new ArgumentOutOfRangeException(Exceptions.Exceptions.FirstNameTooShort);
                if (value.Length > 15)
                    throw new ArgumentOutOfRangeException(Exceptions.Exceptions.FirstNameTooLong);

                firstname = value;
            }
        }

        public string LastName
        {
            get => lastname;
            set
            {
                if (value.Length < 4)
                    throw new ArgumentOutOfRangeException(Exceptions.Exceptions.LastNameTooShort);
                if (value.Length > 15)
                    throw new ArgumentOutOfRangeException(Exceptions.Exceptions.LastNameTooLong);

                lastname = value;
            }
        }

        public int Age { get; set; }
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
    }
}