using LifeSim.Establishments.Job.Enums;

namespace LifeSim.Establishments.Job
{
    public interface IJob
    {
        double MonthSalary { get; set; }

        int WorkHoursPerDay { get; set; }

        ProfessionType Profession { get; set; }
    }
}