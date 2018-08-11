using LifeSim.Establishments.AbstractEstablishment.Contracts;
using System;

namespace LifeSim.Establishments.AbstractEstablishment.Models
{
    public abstract class Establishment : IEstablishment
    {
        private string buildingName;

        protected Establishment()
        {

        }

        public string BuildingName
        {
            get => buildingName;
            set
            {
                if (value == null) throw new ArgumentNullException("Building name cannot be null.");
                if (value.Length == 0) throw new ArgumentException("Building name cannot be empty.");

                buildingName = value;
            }
        }
    }
}
