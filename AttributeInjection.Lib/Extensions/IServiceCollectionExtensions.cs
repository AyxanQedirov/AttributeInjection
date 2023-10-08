using AttributeInjection.Lib.Attributes.Commons;
using AttributeInjection.Lib.Markers;
using AttributeInjection.Lib.Models;
using AttributeInjection.Lib.Tools;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace AttributeInjection.Lib.Extensions
{
    public static class IServiceCollectionExtensions
    {

        public static IServiceCollection AddAttributeInjection(this IServiceCollection services,params  AssemblyRegistrator[] assemblyRegistrators)
        {
            AssemblyTool assemblyTool = new AssemblyTool();
            List<Assembly> assemblies = AssemblyRegistratorToAssembly(assemblyRegistrators.ToList());
            List<Dependecy> dependecies = DefineDependencyCouples(assemblies);

            return services;
        }

        private static List<Dependecy> DefineDependencyCouples(List<Assembly> assemblies)
        {
            List<Dependecy> dependecies = new();

            //Collect All Abstracts
            foreach (Assembly assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {

                    if (type.IsInterface is false)
                        continue;

                    if (HasInjectorAttribute(type) is false)
                        continue;

                    dependecies.Add(new Dependecy(type));
                }
            }

            //Define Concretes


            return dependecies;
        }

        private static bool HasInjectorAttribute(Type type)
        {
            foreach (var attribute in type.CustomAttributes)
            {

                if(attribute.AttributeType.BaseType==typeof(BaseInjector))
                    return true;
            }

            return false;
        }

        private static List<Assembly> AssemblyRegistratorToAssembly(List<AssemblyRegistrator> assemblyRegistrators)
        {
            List<Assembly> result = new();

            foreach(var ar in assemblyRegistrators)
            {
                result.Add(ar.GetAssembly());
            }

            return result;
        }
    }
}
