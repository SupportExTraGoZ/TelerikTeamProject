using System.Linq;
using System.Reflection;
using Autofac;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Contracts;
using LifeSim.Core.CLI.Module.ConsoleManagement.Manager.Models;
using LifeSim.Core.Engine.Commands.Contracts;
using LifeSim.Core.Engine.Commands.Models;
using LifeSim.Core.Engine.Core.Contracts;
using LifeSim.Core.Engine.Core.Models;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Contracts;
using LifeSim.Core.Engine.Core.UserStatusDisplay.Models;
using LifeSim.Core.Engine.Factories;
using LifeSim.Core.Engine.Factories.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Contracts;
using LifeSim.Core.Engine.Menu.Manager.Models;
using LifeSim.Logger.Contracts;
using LifeSim.Player.Options.Contracts;
using LifeSim.Player.Options.Models;
using LifeSim.Player.Randomizer.Contracts;
using LifeSim.Player.Randomizer.Models;
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
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            // Dependencies
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<ConsoleManager>().As<IConsoleManager>().SingleInstance();
            builder.RegisterType<MenuManager>().As<IMenuManager>().SingleInstance();
            builder.RegisterType<Generator>().As<IGenerator>().SingleInstance();
            builder.RegisterType<Logger.Models.Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<UserStatus>().As<IUserStatus>().SingleInstance();
            builder.RegisterType<GamePlayerFactory>().As<IGamePlayerFactory>().SingleInstance();

            // Minor Dependencies
            //builder.RegisterType<OptionsContainer>().As<IOptionsContainer>().SingleInstance().PropertiesAutowired();
        }

        private void RegisterAllCommands(ContainerBuilder builder)
        {
            Assembly.GetExecutingAssembly().DefinedTypes
                    .Where(x => x.ImplementedInterfaces.Contains(typeof(ICommand)) && !x.IsAbstract && !x.IsInterface)
                    .ToList()
                    .ForEach(x =>
                    {
                        builder.RegisterType(x).Named<ICommand>(x.Name.ToLower()).SingleInstance();
                    });
        }
    }
}