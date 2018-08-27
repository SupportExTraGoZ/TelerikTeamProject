using System;
using System.Linq;
using System.Reflection;
using Autofac;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Contracts.Utilities;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Functions.Utilities.UserQuestion.Models;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Models;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Commands.Models;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Core.Models;
using LifeSim.Core.Engine.Core.UserStatus.Contracts;
using LifeSim.Core.Engine.Core.UserStatus.Models;
using LifeSim.Core.Engine.Factories;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Models;
using LifeSim.Core.Engine.Menu.Models;
using LifeSim.Logger.Contracts;
using LifeSim.Player.Options.Contracts;
using LifeSim.Player.Options.Models;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Contracts.Generators;
using LifeSim.Player.Randomizer.Models;
using LifeSim.Player.Randomizer.Models.Generators;
using Module = Autofac.Module;

namespace LifeSim.IoContainer.CLI.InjectionConfig
{
    public class AutofacConfig : Module
    {
        public IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            RegisterConvention(containerBuilder);
            RegisterCoreComponents(containerBuilder);
            RegisterAllCommands(containerBuilder);

            return containerBuilder.Build();
        }

        private void RegisterConvention(ContainerBuilder builder)
        {
            var coreAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(coreAssembly)
                .AsImplementedInterfaces();
        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            // Engine
            builder.RegisterType<Engine>().As<IEngine>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).SingleInstance();

            // Dependencies
            builder.RegisterType<CommandParser>().As<ICommandParser>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).SingleInstance();
            builder.RegisterType<ConsoleManager>().As<IConsoleManager>().PropertiesAutowired().SingleInstance();
            builder.RegisterType<MenuManager>().As<IMenuManager>().PropertiesAutowired().SingleInstance();
            builder.RegisterType<Generator>().As<IGenerator>().PropertiesAutowired().SingleInstance();
            builder.RegisterType<Logger.Models.Logger>().As<ILogger>().PropertiesAutowired().SingleInstance();
            builder.RegisterType<UserStatus>().As<IUserStatus>().PropertiesAutowired().SingleInstance();
            builder.RegisterType<GamePlayerFactory>().As<IGamePlayerFactory>().SingleInstance();

            // Minor Dependencies
            builder.RegisterType<OptionsContainer>().As<IOptionsContainer>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<ConsoleReader>().As<IConsoleReader>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<ConsoleCleaner>().As<IConsoleCleaner>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<UserInteraction>().As<IUserInteraction>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<UserStatus>().As<IUserStatus>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<QuestionAction>().As<IQuestionAction>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<Question>().As<IQuestion>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<MenuLauncher>().As<IMenuLauncher>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<FamilyGenerator>().As<IFamilyGenerator>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<NumberGenerator>().As<INumberGenerator>().SingleInstance().PropertiesAutowired();
            builder.RegisterType<EducationInstitutePicker>().As<IEducationInstitutePicker>().SingleInstance()
                .PropertiesAutowired();
            builder.RegisterType<EducationalInstituteFactory>().As<IEducationalInstituteFactory>().SingleInstance();
            builder.RegisterType<JobFactory>().As<IJobFactory>().SingleInstance();

        }

        private void RegisterAllCommands(ContainerBuilder builder)
        {
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ICommand).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .ToList()
                .ForEach(x => { builder.RegisterType(x).Named<ICommand>(x.Name.ToLower()).SingleInstance(); });
        }
    }
}