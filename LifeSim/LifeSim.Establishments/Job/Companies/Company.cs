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
                if (value == null) throw new ArgumentNullException("Invalid company name.");

                name = value;
            }
        }
    }
}