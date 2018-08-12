﻿using System;
using System.Collections.Generic;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Establishments.Job.Enums;
using LifeSim.Establishments.Job;
using System.Text;

namespace LifeSim.Core.Engine.Commands.Actions.Job
{
    public class ApplyForJobCommand : ICommand
    {
        private readonly IEngine engine;

        public ApplyForJobCommand(IEngine engine)
        {
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            ProfessionType job;
            try
            {
                job = (ProfessionType)Enum.Parse(typeof(ProfessionType), parameters[1].Trim(), true);
            }
            catch (NullReferenceException)
            {
                return "Job Choice cannot be empty...";
            }
            catch (ArgumentException)
            {
                return $"{parameters[1]} was not found in the Jobs List.";
            }

            var player = this.engine.Player;
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("You've sent your CV for to the selected job office.");

            switch (job)
            {
                case ProfessionType.SoftwareEngineer:
                    {
                        if (player.IsSuccessfulAtUniversity)
                        {
                            player.Job = new Establishments.Job.Job(ProfessionType.SoftwareEngineer, 1200, 6, this.engine.GameTime);
                            player.HasJob = true;
                            stringBuilder.AppendLine("Few weeks later, you have been accepted to work at the Software Engineering Company.");
                            stringBuilder.AppendLine($"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.Worker;
                        }
                        else
                        {
                            stringBuilder.AppendLine("Your application for the Software Engineering Company has been declined.");
                            stringBuilder.AppendLine("Try looking and applying for another job.");
                        }
                    }
                    break;
                case ProfessionType.PoliceOfficer:
                    {
                        player.Job = new Establishments.Job.Job(ProfessionType.PoliceOfficer, 1000, 12, this.engine.GameTime);
                        player.HasJob = true;
                        stringBuilder.AppendLine("Few weeks later, you have been accepted to work at the local Police Station.");
                        stringBuilder.AppendLine($"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                        this.engine.PlayerProgress = Player.Enums.PlayerProgress.Worker;
                    }
                    break;
                case ProfessionType.Firefighter:
                    {
                        player.Job = new Establishments.Job.Job(ProfessionType.Firefighter, 1000, 12, this.engine.GameTime);
                        player.HasJob = true;
                        stringBuilder.AppendLine("Few weeks later, you have been accepted to work at the local Fire Station.");
                        stringBuilder.AppendLine($"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                        this.engine.PlayerProgress = Player.Enums.PlayerProgress.Worker;
                    }
                    break;
                case ProfessionType.Scientist:
                    {
                        if (player.IsSuccessfulAtUniversity && player.IsTakingLessons)
                        {
                            player.Job = new Establishments.Job.Job(ProfessionType.Scientist, 1800, 8, this.engine.GameTime);
                            player.HasJob = true;
                            stringBuilder.AppendLine("Few weeks later, you have been accepted to work at the Scientific Research Company.");
                            stringBuilder.AppendLine($"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                            this.engine.PlayerProgress = Player.Enums.PlayerProgress.Worker;
                        }
                        else
                        {
                            stringBuilder.AppendLine("Your application for the Scientific Research Company has been declined.");
                            stringBuilder.AppendLine("Try looking and applying for another job.");
                        }
                    }
                    break;
                case ProfessionType.Accountant:
                    {
                        player.Job = new Establishments.Job.Job(ProfessionType.Accountant, 900, 8, this.engine.GameTime);
                        player.HasJob = true;
                        stringBuilder.AppendLine("Few weeks later, you have been accepted to work as an Accountant in a local Company.");
                        stringBuilder.AppendLine($"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                        this.engine.PlayerProgress = Player.Enums.PlayerProgress.Worker;
                    }
                    break;
            }
            return stringBuilder.ToString();
        }
    }
}