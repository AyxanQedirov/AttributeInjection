using AttributeInjection.Lib.Attributes.Commons;
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

        public static IServiceCollection AddAttributeInjection(this IServiceCollection services)
        {
            AssemblyTool assemblyTool = new AssemblyTool();
            List<Assembly> assemblies = assemblyTool.GetAllAssembliesWhichUseThisLib();
            List<Dependecy> dependecies = DefineDependencyCouples(assemblies);

            return services;
        }

        private static List<Dependecy> DefineDependencyCouples(List<Assembly> assemblies)
        {
            List<Dependecy> dependecies = new List<Dependecy>();

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
    }
}
