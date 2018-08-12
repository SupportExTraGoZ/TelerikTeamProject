using LifeSim.Establishments.AbstractEstablishment.Contracts;
using System;

namespace LifeSim.Establishments.AbstractEstablishment.Models
{
    public abstract class Establishment : IEstablishment
    {
        protected Establishment(string buildingName)
        {
            this.BuildingName = buildingName;
        }

        public string BuildingName { get; set; }
    }
}