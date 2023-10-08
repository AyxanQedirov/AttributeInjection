using AttributeInjection.Lib.Attributes.Commons;
using AttributeInjection.Lib.Attributes.ForConretes;
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

        public static IServiceCollection AddAttributeInjection(this IServiceCollection services, params AssemblyRegistrator[] assemblyRegistrators)
        {
            AssemblyTool assemblyTool = new AssemblyTool();
            List<Assembly> assemblies = AssemblyRegistratorToAssembly(assemblyRegistrators.ToList());
            List<Dependecy> dependecies = DefineDependencyCouples(assemblies);
            AddDependenciesToIoCContainer(services, dependecies);

            return services;
        }

        private static List<Dependecy> DefineDependencyCouples(List<Assembly> assemblies)
        {
            List<Dependecy> dependecies = new();
            CollectAllAbstracts(dependecies, assemblies);
            FindConcretes(dependecies, assemblies);
            return dependecies;
        }
        private static void CollectAllAbstracts(List<Dependecy> dependecies, List<Assembly> assemblies)
        {
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
        }
        private static void FindConcretes(List<Dependecy> dependecies, List<Assembly> assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {

                    if (type.IsInterface is true)
                        continue;

                    bool doesTypeHasUseThisAttribute = type.CustomAttributes.Any(c => c.AttributeType == typeof(UseThis));

                    foreach (Dependecy dependecy in dependecies)
                    {
                        if (!type.IsAssignableTo(dependecy.Abstract))
                            continue;


                        if (dependecy.IsConcreteSetted && !dependecy.DoesHaveUseThisAttribute && !doesTypeHasUseThisAttribute)
                            throw new Exception($"There are multiple options for {dependecy.Abstract.Name}, you can use 'UseThis' attribute to choose implementation.");

                        if (dependecy.IsConcreteSetted && dependecy.DoesHaveUseThisAttribute && doesTypeHasUseThisAttribute)
                            throw new Exception($"There are multiple options for {dependecy.Abstract.Name}, you must use only one 'UseThis' attribute");

                        if (dependecy.IsConcreteSetted && dependecy.DoesHaveUseThisAttribute)
                            continue;

                        dependecy.Concrete = type;
                    }
                }
            }
        }
        private static bool HasInjectorAttribute(Type type)
        {
            foreach (var attribute in type.CustomAttributes)
            {

                if (attribute.AttributeType.BaseType == typeof(BaseInjector))
                    return true;
            }

            return false;
        }
        private static List<Assembly> AssemblyRegistratorToAssembly(List<AssemblyRegistrator> assemblyRegistrators)
        {
            List<Assembly> result = new();

            foreach (var ar in assemblyRegistrators)
            {
                result.Add(ar.GetAssembly());
            }

            return result;
        }
        private static void AddDependenciesToIoCContainer(IServiceCollection services, List<Dependecy> dependecies)
        {
            foreach (Dependecy dependency in dependecies)
            {
                services.AddScoped(dependency.Abstract, dependency.Concrete);
            }
        }
    }
}
