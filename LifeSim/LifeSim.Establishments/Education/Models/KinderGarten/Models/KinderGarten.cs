using LifeSim.Establishments.Education.Models.KinderGarten.Contracts;

namespace LifeSim.Establishments.Education.Models.KinderGarten.Models
{
    public class KinderGarten : EducationalInstitute, IKinderGarten
    {
        public KinderGarten(string name, int startYear, int graduateYear) : base(name, startYear, graduateYear)
        {
            EducationType = Enum.EducationType.KinderGarten;

            kinderGartenNames = new List<string>()
            {
                "Germantown Friends School",
                "Princeton Day School",
                "Collegiate School",
                "Horace Mann School",
                "Trinity School"
            };

            //Check if the given name exist in our data-base
            if (!kinderGartenNames.Contains(name))
            {
                throw new ArgumentException("Name doesn't exist!");
            }

            base.BuildingName = name;

        }

        public IList<string> KinderGartenNames
        {
            get => new List<string>(kinderGartenNames);
        }

    }
}
