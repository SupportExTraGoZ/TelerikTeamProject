using LifeSim.Establishments.AbstractEstablishment.Contracts;

namespace LifeSim.Establishments.AbstractEstablishment.Models
{
    public abstract class Establishment : IEstablishment
    {
        protected Establishment(string buildingName)
        {
            BuildingName = buildingName;
        }

        public string BuildingName { get; set; }
    }
}