using System;
namespace LifeSim.Exceptions.Models
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
}
