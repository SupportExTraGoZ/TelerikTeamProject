using System.Reflection;
using Autofac;
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
            //builder.RegisterType<FurnitureManufacturerEngine>().As<IEngine>().SingleInstance();
            // Write the rest of your bindings... (if needed)
        }
    }
}