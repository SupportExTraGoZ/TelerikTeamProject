using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LifeSim.IoContainer.CLI.InjectionConfig
{
    public class AutofacConfig : Autofac.Module
    {
        public IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            this.RegisterConvention(containerBuilder);
            this.RegisterCoreComponents(containerBuilder);

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
