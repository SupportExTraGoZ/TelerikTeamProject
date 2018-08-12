using LifeSim.Establishments.Education.Models.KinderGarten.Contracts;
using System.Collections.Generic;

namespace LifeSim.Establishments.Education.Models.KinderGarten.Models
{
    public class KinderGarten : EducationalInstitute, IKinderGarten
    {
        //private readonly IList<string> kinderGartens = new List<string>
        //{
        //    "Germantown Friends School",
        //    "Princeton Day School",
        //    "Collegiate School",
        //    "Horace Mann School",
        //    "Trinity School"
        //};

        public KinderGarten(string name, int startYear) : base(name, startYear)
        {
            EducationType = Enum.EducationType.KinderGarten;

            //this.Name = name;
        }

        //public IList<string> KinderGartenNames
        //{
        //    get => new List<string>(kinderGartens);
        //}

    }
}