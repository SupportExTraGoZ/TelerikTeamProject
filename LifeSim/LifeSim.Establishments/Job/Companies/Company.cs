using System;

namespace LifeSim.Establishments.Job.Companies
{
    public class Company : ICompany
    {
        private string name;

        public Company(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value == null) throw new ArgumentNullException("Company name cannot be null or empty.");

                name = value;
            }
        }
    }
}