﻿using System;
using System.Collections.Generic;
using System.Text;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Establishments.Job.Enums;
using LifeSim.Player.Enums;

namespace LifeSim.Core.Engine.Commands.Actions.Job
{
    public class ApplyForJobCommand : ICommand
    {
        private readonly IEngine engine;
        private readonly IGameFactory factory;

        public ApplyForJobCommand(IEngine engine, IGameFactory factory)
        {
            this.engine = engine;
            this.factory = factory;
        }

        public string Name { get; set; }
        public IList<string> Parameters { get; set; }

        public string Execute()
        {
            ProfessionType job;
            try
            {
                job = (ProfessionType) Enum.Parse(typeof(ProfessionType), Parameters[0], true);
            }
            catch (NullReferenceException)
            {
                return "Job Choice cannot be empty...";
            }
            catch (ArgumentException)
            {
                return $"{Parameters[0]} was not found in the Jobs List.";
            }

            var player = engine.Player;
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("You've sent your CV for to the selected job office.");

            switch (job)
            {
                case ProfessionType.SoftwareEngineer:
                {
                    if (player.IsSuccessfulAtUniversity)
                    {
                        if (player.IsSuccessfulAtUniversity)
                        {
                            player.Job = factory.JobFactory.CreateJob(ProfessionType.SoftwareEngineer,
                                1200, 6, engine.GameTime);

                            stringBuilder.AppendLine(
                                "Few weeks later, you have been accepted to work at the Software Engineering Company.");
                            stringBuilder.AppendLine(
                                $"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                            engine.PlayerProgress = PlayerProgress.Worker;
                        }
                        else
                        {
                            stringBuilder.AppendLine("Few weeks later, your receive an answer that...");
                            stringBuilder.AppendLine(
                                "Your application for the Software Engineering Company has been declined.");
                            stringBuilder.AppendLine("Try looking and applying for another job.");
                        }
                    }
                    else
                    {
                        stringBuilder.AppendLine(
                            "Your application for the Software Engineering Company has been declined.");
                        stringBuilder.AppendLine("Try looking and applying for another job.");
                    }
                }
                    break;
                case ProfessionType.PoliceOfficer:
                {
                    player.Job = factory.JobFactory.CreateJob(ProfessionType.PoliceOfficer, 1000, 12, engine.GameTime);

                    stringBuilder.AppendLine(
                        "Few weeks later, you have been accepted to work at the local Police Station.");
                    stringBuilder.AppendLine(
                        $"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                    engine.PlayerProgress = PlayerProgress.Worker;
                }
                    break;
                case ProfessionType.Firefighter:
                {
                    player.Job = factory.JobFactory.CreateJob(ProfessionType.Firefighter, 1000, 12, engine.GameTime);

                    stringBuilder.AppendLine(
                        "Few weeks later, you have been accepted to work at the local Fire Station.");
                    stringBuilder.AppendLine(
                        $"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                    engine.PlayerProgress = PlayerProgress.Worker;
                }
                    break;
                case ProfessionType.Scientist:
                {
                    if (player.IsSuccessfulAtUniversity && player.HasTakenLessons)
                    {
                        player.Job = factory.JobFactory.CreateJob(ProfessionType.Scientist, 1800, 8, engine.GameTime);

                        stringBuilder.AppendLine(
                            "Few weeks later, you have been accepted to work at the Scientific Research Company.");
                        stringBuilder.AppendLine(
                            $"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                        engine.PlayerProgress = PlayerProgress.Worker;
                    }
                    else
                    {
                        if (player.IsSuccessfulAtUniversity && player.HasTakenLessons)
                        {
                            player.Job =
                                factory.JobFactory.CreateJob(ProfessionType.Scientist, 1800, 8, engine.GameTime);

                            stringBuilder.AppendLine(
                                "Few weeks later, you have been accepted to work at the Scientific Research Company.");
                            stringBuilder.AppendLine(
                                $"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                            engine.PlayerProgress = PlayerProgress.Worker;
                        }
                        else
                        {
                            stringBuilder.AppendLine("Few weeks later, your receive an answer that...");
                            stringBuilder.AppendLine(
                                "Your application for the Scientific Research Company has been declined.");
                            stringBuilder.AppendLine("Try looking and applying for another job.");
                        }
                    }
                }
                    break;
                case ProfessionType.Accountant:
                {
                    player.Job = factory.JobFactory.CreateJob(ProfessionType.Accountant, 900, 8, engine.GameTime);

                    stringBuilder.AppendLine(
                        "Few weeks later, you have been accepted to work as an Accountant in a local Company.");
                    stringBuilder.AppendLine(
                        $"You're now working {player.Job.WorkHoursPerDay} hours per day, for ${player.Job.MonthlySalary} per month.");
                    engine.PlayerProgress = PlayerProgress.Worker;
                }
                    break;
            }

            return stringBuilder.ToString();
        }
    }
}