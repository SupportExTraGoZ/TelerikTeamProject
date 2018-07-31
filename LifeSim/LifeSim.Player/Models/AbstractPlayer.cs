using System;
using LifeSim.Player.Contracts;
using LifeSim.Player.Enums;
namespace LifeSim.Player.Models
{
    public class AbstractPlayer : IPlayer
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
                    throw new Exception(ExceptionHandler.Exceptions.FirstNameTooShort);
                if (value.Length > 15)
                    throw new Exception(ExceptionHandler.Exceptions.FirstNameTooLong);

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
                    throw new Exception(ExceptionHandler.Exceptions.LastNameTooShort);
                if (value.Length > 15)
                    throw new Exception(ExceptionHandler.Exceptions.LastNameTooLong);

                this.lastname = value;
            }
        }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public Birthplaces Birthplace { get; set; }
        public DateTime BirthDate { get; set; }

        public AbstractPlayer(string firstname, string lastname, GenderType gender, Birthplaces birthplace)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Gender = gender;
            this.Birthplace = birthplace;
        }
    }
}
